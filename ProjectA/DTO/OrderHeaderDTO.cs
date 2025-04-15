using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectB.DTO
{
    public class OrderHeaderDTO
    {
       
        public string? MawbReference { get; set; }
        public DateTime? MawbDate { get; set; }
        public string? CarrierCode { get; set; }
        public string? Carrier { get; set; }
        public string? FlightID { get; set; }
        public string? FromLoc { get; set; }
        public string? FromLocName { get; set; }
        public string? ToLoc { get; set; }
        public string? ToLocName { get; set; }
        public string? ShipperCode { get; set; }
        public string? ShipperName { get; set; }
        public string? ReceiverCode { get; set; }
        public string? ReceiverName { get; set; }
        public string? BagNumber { get; set; }
        public string? Notes { get; set; }
        public int? TotalWeight { get; set; }
        public List<OrderDetailDTO> OrderDetails { get; set; }

    }

    public class OrderDetailDTO
    {

        //[ForeignKey]
        public string? MawbReference { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? ConsignorName { get; set; }
        public string? ConsignorAddress1 { get; set; }
        public string? ConsignorAddress2 { get; set; }
        public string? ConsignorAddress3 { get; set; }
        public string? ConsignorAddress4 { get; set; }
        public string? ConsignorAddress5 { get; set; }
        public string? ConsignorLocationName { get; set; }
        public decimal? ConsignorCountrySID { get; set; }
        public string? ConsignorState { get; set; }
        public string? ConsignorPostCode { get; set; }
        public string? ConsignorContact { get; set; }
        public string? ConsignorPhone { get; set; }
        public string? ConsignorFax { get; set; }
        public string? ConsignorEmail { get; set; }
        public string? ConsignorCountryCode { get; set; }
        public string? ConsignorCountryName { get; set; }
        public string? ConsigneeName { get; set; }
        public string? ConsigneeAddress1 { get; set; }
        public string? ConsigneeAddress2 { get; set; }
        public string? ConsigneeAddress3 { get; set; }
        public string? ConsigneeAddress4 { get; set; }
        public string? ConsigneeAddress5 { get; set; }
        public string? ConsigneeLocationName { get; set; }
        public decimal? ConsigneeCountrySID { get; set; }
        public string? ConsigneeState { get; set; }
        public string? ConsigneePostCode { get; set; }
        public string? ConsigneeContact { get; set; }
        public string? ConsigneePhone { get; set; }
        public string? ConsigneePhone2 { get; set; }
        public string? ConsigneeFax { get; set; }
        public string? ConsigneeEmail { get; set; }
        public string? ConsigneeAddressResidential { get; set; }
        public decimal? Weight { get; set; }
        public string? WeightMeasure { get; set; }
        public decimal? CubicLength { get; set; }
        public decimal? CubicWidth { get; set; }
        public decimal? CubicHeight { get; set; }
        public decimal? CubicWeight { get; set; }
        public string? ServiceType { get; set; }
        public string? GoodsDesc { get; set; }
        public string? Notes { get; set; }
        public decimal? CustomsValue { get; set; }
        public string? CustomsCurrencyCode { get; set; }
        public string? DeliveryInstructions { get; set; }

    }
}
