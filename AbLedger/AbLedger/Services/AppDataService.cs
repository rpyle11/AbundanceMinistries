using AbLedger.Data;
using AbLedger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;
using AbLedger.Entities;

namespace AbLedger.Services
{
    public class AppDataService : IDisposable
    {
        private AbLedgerDataContext Context { get; set; }

        public AppDataService(AbLedgerDataContext context)
        {
            Context = context;
        }

        public async void Dispose()
        {
            await Context.DisposeAsync();
        }
        public async Task LogError(AppErrors error)
        {
            
            await Context.AppErrors.AddAsync(error);
            await Context.SaveChangesAsync();

        }
        public async Task<List<TransactionDisplayDto>> GetTransactionsByDate(DateTime beginDate, DateTime endDate)
        {
            try
            {
               
                var tranList = await Context.Transactions.Where(w => w.TransDate >= beginDate && w.TransDate <= endDate)
                    .ToListAsync();

                if (tranList.Any())
                {
                    var returnList = new List<TransactionDisplayDto>();

                    foreach (var trans in tranList.Where(trans => trans.TransDate != null))
                    {
                        var acctName = await GetAccount(trans.AccountId);
                        var payeeName = await GetPayee(trans.PayeeId);
                        if (trans.TransDate == null || acctName ==null || payeeName==null) continue;
                        var tran = new TransactionDisplayDto
                        {
                            Account = acctName.Account,
                            Payee = payeeName.PayeeName,
                            Id = trans.Id,
                            TransDate = trans.TransDate.Value,
                            CheckNum = trans.CheckNum,
                            Memo = trans.Memo,
                            EndingBalance = trans.EndBalance,
                            BeginningBalance = trans.BeginBalance
                        };


                        if (!trans.Deposit)
                        {
                            tran.Payment = trans.TransAmount;
                            tran.Deposit = null;
                        }
                        else
                        {
                            tran.Deposit = trans.TransAmount;
                            tran.Payment = null;
                        }

                        returnList.Add(tran);
                    }

                    return returnList;
                }
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
               
            }


            return null;
        }

        private async Task<Accounts> GetAccount(int accountId)
        {
            try
            {
                var acct = await Context.Accounts.FirstOrDefaultAsync(f => f.Id == accountId);

                return acct;
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
               
            }

            return null;
        }

        private async Task<Payees> GetPayee(int payeeId)
        {
            try
            {
                var payee = await Context.Payees.FirstOrDefaultAsync(f => f.Id == payeeId);

                return payee;
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
               
            }

            return null;
        }

        #region Maintenance
        public async Task<List<Accounts>> GetAllAccounts()
        {
            try
            {
                return await Context.Accounts.OrderBy(o => o.Account).ToListAsync();
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
            }

            return null;
        }

        public async Task<Accounts> AddUpdateAccount(Accounts account)
        {
            try
            {

                if (account.Id == 0)
                {
                    await Context.Accounts.AddAsync(account);
                    await Context.SaveChangesAsync();

                    return account;
                }

                var inDb = await Context.Accounts.FirstOrDefaultAsync(f => f.Id == account.Id);
                if (inDb != null)
                {
                    inDb.Account = account.Account;
                    inDb.Active = account.Active;

                    Context.Accounts.Update(inDb);
                    await Context.SaveChangesAsync();
                    return inDb;
                }
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
               
            }

            return null;
        }

        public async Task<List<Payees>> GetAllPayees()
        {
            try
            {
                return await Context.Payees.OrderBy(o => o.PayeeName).ToListAsync();
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
            }

            return null;
        }


        public async Task<Payees> AddUpdatePayee(Payees payee)
        {
            try
            {

                if (payee.Id == 0)
                {
                    await Context.Payees.AddAsync(payee);
                    await Context.SaveChangesAsync();

                    return payee;
                }

                var inDb = await Context.Payees.FirstOrDefaultAsync(f => f.Id == payee.Id);
                if (inDb != null)
                {
                    inDb.PayeeName = payee.PayeeName;
                    inDb.Active = payee.Active;

                    Context.Payees.Update(inDb);

                    return inDb;
                }
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
               
            }

            return null;
        }

        public async Task<bool> BackupDatabase()
        {
            try
            {
                await Context.DisposeAsync();
                var dbUnc = ConfigurationManager.ConnectionStrings["DbCnn"].ConnectionString.Replace("DataSource=","");
                if (File.Exists(dbUnc))
                {
                    File.Copy(dbUnc, Path.Combine(Properties.Settings.Default.BackupFolder, "AbLedgerData.db"),true);
                    Context = new AbLedgerDataContext();

                    return true;
                }
                
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
                
            }

            return false;
        }

        public async Task<bool> RestoreDatabase(string selectedDatabase)
        {
            try
            {
                await Context.DisposeAsync();
                var dbUnc = ConfigurationManager.ConnectionStrings["DbCnn"].ConnectionString.Replace("DataSource=", "");
                if (File.Exists(selectedDatabase))
                {
                    File.Copy(selectedDatabase, dbUnc, true);
                    Context = new AbLedgerDataContext();

                    return true;
                }

            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });

            }

            return false;
        }
        #endregion



        #region Transaction

        public async Task<List<Payees>> GetActivePayees()
        {
            try
            {
                return await Context.Payees.Where(w => w.Active == true).OrderBy(o => o.PayeeName).ToListAsync();
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
            }

            return null;
        }

        public async Task<List<Accounts>> GetActiveAccounts()
        {
            try
            {
                return await Context.Accounts.Where(w => w.Active == true).OrderBy(o => o.Account).ToListAsync(); ;
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
            }

            return null;
        }

        public async Task<List<Transactions>> FutureTransactions(DateTime dtTransDate)
        {
            try
            {
                var trans = await Context.Transactions.Where(w => w.TransDate > dtTransDate).ToListAsync();

                return trans;
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
            }

            return null;
        }

        public async Task<Transactions> GetLastBalanceByDate(DateTime dtTranDate)
        {
            try
            {
                var maxTran = await Context.Transactions.MaxAsync(m => m.TransDate);

                if (maxTran != null)
                {
                    if (dtTranDate > maxTran.Value)
                    {
                        return await Context.Transactions.FirstOrDefaultAsync(w => w.TransDate == maxTran.Value);
                       
                    }

                    var mxDate = await Context.Transactions.Where(w => w.TransDate <= dtTranDate).MaxAsync(m => m.TransDate);
                    var maxId = await Context.Transactions.FirstOrDefaultAsync(f => f.TransDate == mxDate);

                    if (maxId != null)
                    {
                        var rec = await Context.Transactions.FirstOrDefaultAsync(f => f.Id == maxId.Id);
                        
                        return rec;
                    }
                }
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
            }

            return null;
        }

        public async Task<Transactions> AddTransaction(Transactions transaction)
        {
            try
            {
                await Context.Transactions.AddAsync(transaction);
                await Context.SaveChangesAsync();

                return transaction;
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
            }

            return null;
        }


        public async Task<bool> CheckForTransactionWithGreaterDate(decimal beginBalance, List<Transactions> futureTransactions)
        {
            try
            {
                if (!futureTransactions.Any()) return true;
                decimal startingBalance = 0;
                decimal runningBalance = 0;
                for (var i = 0; i <= futureTransactions.OrderBy(o => o.TransDate).Count() - 1; i++)
                {
                    if (i == 0)
                    {
                        startingBalance =  beginBalance;

                    }

                       
                    if (futureTransactions[i].Deposit)
                    {
                        var transAmount = futureTransactions[i].TransAmount;
                        if (transAmount != null)
                            runningBalance = startingBalance + transAmount.Value;
                    }
                    else
                    {
                        var transAmount = futureTransactions[i].TransAmount;
                        if (transAmount != null)
                            runningBalance = startingBalance - transAmount.Value;
                    }

                    await UpdateTransaction(futureTransactions[i].Id, startingBalance, runningBalance);
                    startingBalance = runningBalance;
                }

                return true;
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
            }

            return false;
        }

        private async Task UpdateTransaction(int id, decimal beginBalance, decimal endBalance)
        {
            try
            {
                var inDb = await Context.Transactions.FirstOrDefaultAsync(f => f.Id == id);
                if (inDb == null) return;
                inDb.BeginBalance = beginBalance;
                inDb.EndBalance = endBalance;

                Context.Transactions.Update(inDb);
                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                await LogError(new AppErrors
                {
                    AppMethod = MethodName.GetMethodName(MethodBase.GetCurrentMethod()),
                    ErrorDate = DateTime.Now,
                    ErrorMsg = e.Message
                });
            }
        }
        #endregion




    }
}
