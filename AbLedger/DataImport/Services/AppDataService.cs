
using DataImport.Data;
using DataImport.OldData;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Accounts = DataImport.OldData.Accounts;
using Payees = DataImport.OldData.Payees;
using Transactions = DataImport.Entities.Transactions;

namespace DataImport.Services
{
    public class AppDataService : IDisposable
    {
        private AbLedgerDataContext Context { get; set; }

        public AppDataService()
        {
            Context = new AbLedgerDataContext();
        }

        public async void Dispose()
        {
            await Context.DisposeAsync();
        }
        public async Task LogError(Entities.AppErrors error)
        {
            await Context.AppErrors.AddAsync(error);
            await Context.SaveChangesAsync();

        }
     

    
       

        public async Task<bool> ImportOldData()
        {
            try
            {

                await using var context = new AbLedgerDataContext();
                if (!await ClearData(context)) return true;
                //accounts
                foreach (var account in await GetAccountsForImport())
                {
                    await context.Accounts.AddAsync(new Entities.Accounts
                    {
                        Account = account.VcAccount,
                        Active = account.BlnActive
                    });
                }
                await context.SaveChangesAsync();

                foreach (var payee in await GetPayeesForImport())
                {
                    await context.Payees.AddAsync(new Entities.Payees()
                    {
                        Active = payee.BlnActive,
                        Address = payee.VcAddress,
                        PayeeName = payee.VcPayee
                    });
                }
                await context.SaveChangesAsync();

                foreach (var transaction in await GetAppTransactionsForImport())
                {
                    var trans = new Transactions
                    {
                        TransDate = transaction.TransDate,
                        EndBalance = transaction.EndBalance,
                        BeginBalance = transaction.BeginBalance,
                        CheckNum = transaction.CheckNum,
                        Memo = transaction.Memo,
                        Payment = transaction.Payment.Value,
                        Deposit = transaction.Deposit.Value,
                        TransAmount = transaction.TransAmount,



                    };

                    var newPayee = await GetPayeeFromOldId(transaction.PayeeId.Value, context);
                    trans.PayeeId = newPayee.Id;

                    var newAcct = await GetAccountFromOldId(transaction.AccountId.Value, context);
                    trans.AccountId = newAcct.Id;

                    await context.Transactions.AddAsync(trans);

                }

                await context.SaveChangesAsync();


                return true;
            }
            catch (DataException e)
            {
                
                Console.WriteLine(e.Message);
            }

            return false;
        }

        private static async Task<bool> ClearData(AbLedgerDataContext context)
        {

            try
            {
              
                var allErrors = await context.AppErrors.ToListAsync();
                var allPayees = await context.Payees.ToListAsync();
                var allAccounts = await context.Accounts.ToListAsync();
                var allTransactions = await context.Transactions.ToListAsync();

                context.AppErrors.RemoveRange(allErrors);
                context.Accounts.RemoveRange(allAccounts);
                context.Payees.RemoveRange(allPayees);
                context.Transactions.RemoveRange(allTransactions);

                await context.SaveChangesAsync();


                return true;
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
            }

            return false;
        }

        private async Task<List<Accounts>> GetAccountsForImport()
        {
            AbundanceministriesContext oldContext = null;
            try
            {
                oldContext = new AbundanceministriesContext();

                return await oldContext.Accounts.ToListAsync();
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (oldContext != null) await oldContext.DisposeAsync();
            }

            return null;
        }

        private async Task<List<Payees>> GetPayeesForImport()
        {
            AbundanceministriesContext oldContext = null;
            try
            {
                oldContext = new AbundanceministriesContext();

                return await oldContext.Payees.ToListAsync();
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (oldContext != null) await oldContext.DisposeAsync();
            }

            return null;
        }

        private async Task<List<OldData.Transactions>> GetAppTransactionsForImport()
        {
            AbundanceministriesContext oldContext = null;
            try
            {
                oldContext = new AbundanceministriesContext();

                return await oldContext.Transactions.ToListAsync();
            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (oldContext != null) await oldContext.DisposeAsync();
            }

            return null;
        }

        private async Task<Entities.Payees> GetPayeeFromOldId(int oldPayeeId, AbLedgerDataContext context)
        {
            var ctx = new AbundanceministriesContext();
            try
            {

                var oldPayee = await ctx.Payees.FirstOrDefaultAsync(f => f.PayeeId == oldPayeeId);

                return await context.Payees.FirstOrDefaultAsync(f => f.PayeeName == oldPayee.VcPayee);


            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                await ctx.DisposeAsync();
            }

            return null;

        }
        private async Task<Entities.Accounts> GetAccountFromOldId(int oldAcctId, AbLedgerDataContext context)
        {
            var ctx = new AbundanceministriesContext();
            try
            {

                var oldAcct = await ctx.Accounts.FirstOrDefaultAsync(f => f.AccountId == oldAcctId);

                return await context.Accounts.FirstOrDefaultAsync(f => f.Account == oldAcct.VcAccount);


            }
            catch (DataException e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                await ctx.DisposeAsync();
            }

            return null;

        }


     


       
    }
}
