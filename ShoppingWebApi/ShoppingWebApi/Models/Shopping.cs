using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingWebApi.Models
{
    public class Shopping
    {
    }
    
    public partial class result
    {
        public int success { get; set; }
        public string msg { get; set; }

    }

    public partial class tblLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public long UserId { get; set; }
    }

    public partial class tblItemMasterModel
    {
        public Nullable<decimal> ID { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string ItemNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public long srno { get; set; }
    }

    public partial class tblItemTypeModel
    {
        public Nullable<long> ID { get; set; }
        public string ItemType { get; set; }
        public long srno { get; set; }
    }

    public partial class tblPurchaseModel
    {
        public Nullable<long> InvoiceID { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string ShopName { get; set; }
        public string SupplierName { get; set; }
        public string Address { get; set; }
        public string GST { get; set; }
        public Nullable<decimal> GrossAmount { get; set; }
        public Nullable<decimal> CGSTPer { get; set; }
        public Nullable<decimal> CGSTAmt { get; set; }
        public Nullable<decimal> SGSTPer { get; set; }
        public Nullable<decimal> SGSTAmt { get; set; }
        public Nullable<decimal> GrandTotal { get; set; }
        public long srno { get; set; }
    }

    public partial class tblPurchaseDetailModel
    {
        public Nullable<long> ID { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string ItemNo { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> Amount { get; set; }
        public string HSN { get; set; }
        public long srno { get; set; }
    }

    public partial class tblStockModel
    {
        public Nullable<long> StockID { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemNo { get; set; }
        public Nullable<decimal> StockQty { get; set; }
        public Nullable<decimal> StockRate { get; set; }
        public long Srno { get; set; }
    }

    public partial class tblSaleModel
    {
        public Nullable<long> SaleInvoiceID { get; set; }
        public Nullable<System.DateTime> SaleDate { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public Nullable<decimal> TotalQty { get; set; }
        public Nullable<decimal> GrandAmt { get; set; }
        public long srno { get; set; }
    }

    public partial class tblSaleDetailModel
    {
        public long SaleID { get; set; }
        public string SaleItemName { get; set; }
        public string SaleItemNo { get; set; }
        public Nullable<decimal> SaleQty { get; set; }
        public Nullable<decimal> SaleRate { get; set; }
        public Nullable<decimal> SaleAmount { get; set; }
        public long srno { get; set; }
    }

    public partial class tblRegModel
    {
        public Nullable<long> Regid { get; set; }
        public string CustomerName { get; set; }
        public string Custaddress { get; set; }
        public string MobileNo { get; set; }
        public Nullable<System.DateTime> RegDate { get; set; }
        public string City { get; set; }
        public string PinNo { get; set; }
        public long srno { get; set; }
    }

    public partial class tblOrderModel
    {
        public Nullable<decimal> ID { get; set; }
        public string ItemType { get; set; }
        public string ItemName { get; set; }
        public string ItemNo { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public Nullable<decimal> TotAmt { get; set; }
        public string CardId { get; set; }
        public string ActDct { get; set; }
        public long srno { get; set; }
    }

    public partial class tblCardMasterModel
    {
        public long CardId { get; set; }
        public string ActDact { get; set; }
        public string CardNo { get; set; }
        public string CardPinno { get; set; }
    }
}