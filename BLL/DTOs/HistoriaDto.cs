using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTOs
{
    public record HistoriaDto(int ID, string Imie, string Nazwisko, int? GrupaID, string TypAkcji, DateTime Data);

}
