﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANE.Domain.Entities
{
    public class Rejseplan
    {
        public int Id { get; set; }
        public int? KundeId { get; set; }
        public string? Titel { get; set; }
        public string? Beskrivelse { get; set; }
        public int? AntalVoksne { get; set; }
        public int? AntalBørn { get; set; }
        public string Lufthavn { get; set; } 
        public double? FlyPris { get; set; }
        public int? AntalDage { get; set; }
        public double? TotalPris { get; set; }
        public DateTime AfrejseTidspunkt { get; set; }

        // Liste af ture tilknyttet bookingen

        public List<Tur> Ture { get; set; } = new();
        // Status‐flags
        public string OpfølgningNote { get; set; } 
        public Status? RejseplanStatus { get; set; }
        public enum Status
        {
            RejseplanOprettet,
            TilbudSendt,
            AfventerOpfølgning,
            OpfølgningSvaret,
            TilbudAccepteret,
            RejseBooket,
            Annulleret,
            Udskudt
        }
        [Timestamp]
        public byte[] RowVersion { get; set; } = Array.Empty<byte>();

        public int GetAntalOvernatninger()
        {
            return Ture.Sum(t => t.GetAntalOvernatninger());
        }

        public DateTime GetHjemRejseDag()
        {
            return AfrejseTidspunkt.AddDays(GetAntalDage());
        }

        public int GetAntalDage()
        {
            return Ture.Sum(t => t.GetAntalDage());
        }

        public double GetTotalPrisUdenFly()
        {
            return Ture.Sum(t => t.Pris);
        }

        public string PrintTotalPrisPrPerson()
        {
            double totalPris = GetTotalPrisUdenFly() + (FlyPris ?? 0);
            return totalPris.ToString("C", new CultureInfo("da-DK"));
        }
    }
}
