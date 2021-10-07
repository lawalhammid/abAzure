using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationApi.ViewModel.Parameters
{
    public class TransactionLogParam
    {
        public string UserType { get; set; }
        public string TempaTag { get; set; }
        public string GroupTag { get; set; }
        public DateTime? TransCompleteDate { get; set; }
        public Decimal Amount { get; set; }
        public Decimal? AmountToPay { get; set; }
        
        public string DrAcct { get; set; }
        public string DrAcctName { get; set; }
        public string CrAcct { get; set; }
        public string CrAcctName { get; set; }
        public string DrBankCode { get; set; }
        public string CrBankCode { get; set; }
        public string DrBankBranch { get; set; }
        public string CrBankBranch { get; set; }
        public string DrAcctBBAN { get; set; }
        public string CrAcctBBAN { get; set; }
        public string TransResponsecode { get; set; }
        public string TransResponseDescription { get; set; }
        public string Status { get; set; }
        public string Naration { get; set; }
        public string TransferType { get; set; }
        public string DrAcctEmail { get; set; }
        public string DrAcctPhoneNo { get; set; }
        public string CrAcctEmail { get; set; }
        public string CrAcctPhoneNo { get; set; }
        public string Channel { get; set; }
        public string CompanyCode { get; set; }
        public string DrAcctStatus { get; set; }
        public string CrAcctStatus { get; set; }
        public string RejectionReason { get; set; }
        public string DrCurrency { get; set; }
        public DateTime? DateVerified { get; set; }
        public DateTime? DateAuthorised { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime? DateRejected { get; set; }
        public string RejectedById { get; set; }
        public DateTime? DateClosed { get; set; }
        public string ClosedBy { get; set; }
        public string BatchId { get; set; }
        public int SequenceNo { get; set; }
        public bool? IsBulkTransfer { get; set; }
        public string TranCode { get; set; }
        public string TaxRate { get; set; }
        public decimal? TaxAmount { get; set; }
        public bool? IsGroupTrans { get; set; }
        public string ApproveBy { get; set; }
        public DateTime? ApproveDate { get; set; }

    }

}
