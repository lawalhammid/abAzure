using AuthenticationApi.Entities;
using AuthenticationApi.Models;
using AuthenticationApi.ViewModel.Parameters;
using AuthenticationApi.ViewModel.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.IRepositories
{
    public interface ITransactions
    {
        Task<string> GetTransRef(string UserType);
        Task<decimal> GetUserWalletBalanceByWalletNo(string UserId);
        Task<AppResponse> BuyTime(AirtimeParam AirtimeParam, string TransRef);
        Task<AppResponse> BuyData(DataParam DataParam);
        Task<TransactionLog> InsertTransaction(TransactionLogParam transactionLogParam);
        Task<AppResponse> UpateTransaction(TransactionLog TransactionLog, bool TransStatus);

        Task<ResponseWallet> UpdateBalanceForWallet(TransactionLogParam transactionLogParam, string TempaTransRef, long TransaclogId, string ApproveBy = null);

        Task<AppResponse> InsertErrorUpdateWalletBalance(ErrorUpdateWalletBalance ErrorUpdateWalletBalance);

        Task<IEnumerable<TransHisResponse>> GetTransHisByWallet(string WalletAcct);
    }
}
