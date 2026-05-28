using CW21.Presentation.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace CW21.Presentation.Service
{
    public class AuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
    }
}
