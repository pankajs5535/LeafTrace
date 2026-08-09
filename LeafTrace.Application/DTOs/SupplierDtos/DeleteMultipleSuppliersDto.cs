using System;
using System.Collections.Generic;
using System.Text;

namespace LeafTrace.Application.DTOs.SupplierDtos
{
    public class DeleteMultipleSuppliersDto
    {
        public List<int> Ids { get; set; } = new();
    }
}