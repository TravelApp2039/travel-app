using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje
{
    public abstract class SoyutFabrika
    {
        public abstract Ulasim UlasimBilgi();
        public abstract Konaklama KonaklamaBilgi();
    }


    public class Otobus_Otel : SoyutFabrika
    {
        public override Konaklama KonaklamaBilgi()
        {
            return new Otel();
        }

        public override Ulasim UlasimBilgi()
        {
            return new otobus();
        }
    }

    public class Ucak_Otel : SoyutFabrika
    {
        public override Konaklama KonaklamaBilgi()
        {
            return new Otel();
        }

        public override Ulasim UlasimBilgi()
        {
            return new ucak();
        }
    }

    public class Otobus_Cadir : SoyutFabrika
    {
        public override Konaklama KonaklamaBilgi()
        {
            return new Cadir();
        }

        public override Ulasim UlasimBilgi()
        {
            return new otobus();
        }
    }

    public class Ucak_Cadir : SoyutFabrika
    {
        public override Konaklama KonaklamaBilgi()
        {
            return new Cadir();
        }

        public override Ulasim UlasimBilgi()
        {
            return new ucak();
        }
    }
}
