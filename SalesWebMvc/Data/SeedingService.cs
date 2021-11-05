using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWebMvc.Models;
using SalesWebMvc.Models.Enums;

namespace SalesWebMvc.Data
{
    public class SeedingService
    {
        private SalesWebMvcContext _context;

        public SeedingService(SalesWebMvcContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Department.Any() ||
                _context.Seller.Any() ||
                _context.SalesRecord.Any()) // Verifica se há algum registro na tabela, caso sim, anula a operação.
            {
                return; // Anula, banco já populado.
            }

            Department d1 = new Department(1, "Computers");
            Department d2 = new Department(2, "Eletronics");
            Department d3 = new Department(3, "Fashion");
            Department d4 = new Department(4, "Books");
            Department d5 = new Department { Id = 5, Name = "Sports" }; // Sem construtor. 

            Seller s1 = new Seller(1, "Bob Brown", "bob@gmail.com", new DateTime(1998, 4, 4), 1000.0, d1);
            Seller s2 = new Seller(2, "Maria Green", "maria@gmail.com", new DateTime(1992, 8, 6), 1500.0, d1);
            Seller s3 = new Seller(3, "Alex Grey", "alex@gmail.com", new DateTime(2000, 5, 21), 2200.0, d2);
            Seller s4 = new Seller(4, "Martha Red", "martha@gmail.com", new DateTime(1985, 5, 22), 3500.0, d3);
            Seller s5 = new Seller(5, "Donald Blue", "donald@gmail.com", new DateTime(1987, 2, 12), 1200.0, d4);
            Seller s6 = new Seller(6, "Alex Pink", "alex@gmail.com", new DateTime(1999, 9, 7), 1350.0, d5);

            SalesRecord r1 = new SalesRecord(1, new DateTime(2021, 09, 25), 11000.0, SaleStatus.Billed, s1);
            SalesRecord r2 = new SalesRecord(2, new DateTime(2021, 09, 25), 11000.0, SaleStatus.Billed, s2);
            SalesRecord r3 = new SalesRecord(3, new DateTime(2021, 09, 25), 11000.0, SaleStatus.Billed, s3);

            _context.Department.AddRange(d1, d2, d4); // Adicionar vários objetos de uma vez.

            _context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

            _context.SalesRecord.AddRange(r1, r2, r3);

            _context.SaveChanges();
        }
    }
}
