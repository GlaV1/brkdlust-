//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BarkodluSatis
{
    using System;
    using System.Collections.Generic;
    
    public partial class İslemOzet
    {
        public int Id { get; set; }
        public Nullable<int> IslemNo { get; set; }
        public Nullable<bool> İade { get; set; }
        public string OdemeSekli { get; set; }
        public Nullable<double> Nakit { get; set; }
        public Nullable<double> Karrt { get; set; }
        public Nullable<bool> Gelir { get; set; }
        public Nullable<bool> Gider { get; set; }
        public Nullable<double> AlisFiyatToplam { get; set; }
        public string Acıklama { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string Kullanici { get; set; }
    }
}
