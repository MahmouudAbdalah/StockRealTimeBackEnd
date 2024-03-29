﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using DomainLayer.Common;
using System;
using System.Collections.Generic;

namespace DomainLayer.Models;

public partial class Order:BaseDomain
{

    public int Id { get; set; }

    public string StockSymbol { get; set; }

    public string OrderType { get; set; }

    public int Quantity { get; set; }

    public virtual ICollection<OrdersHistory> OrdersHistories { get; set; } = new List<OrdersHistory>();
}