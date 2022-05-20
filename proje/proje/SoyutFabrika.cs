using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proje
{
    public abstract class SoyutFabrika
    {
        public abstract Ulasim ulasimbilgi();
        public abstract Konaklama konaklamabilgi();
    }


    public class Otobus_otel : SoyutFabrika
    {
        public override Konaklama konaklamabilgi()
        {
            return new Otel();
        }

        public override Ulasim ulasimbilgi()
        {
            return new otobus();
        }
    }

    public class Ucak_Otel : SoyutFabrika
    {
        public override Konaklama konaklamabilgi()
        {
            return new Otel();
        }

        public override Ulasim ulasimbilgi()
        {
            return new ucak();
        }
    }

    public class Otobus_Cadir : SoyutFabrika
    {
        public override Konaklama konaklamabilgi()
        {
            return new Cadir();
        }

        public override Ulasim ulasimbilgi()
        {
            return new otobus();
        }
    }

    public class Ucak_Cadir : SoyutFabrika
    {
        public override Konaklama konaklamabilgi()
        {
            return new Cadir();
        }

        public override Ulasim ulasimbilgi()
        {
            return new ucak();
        }
    }
}
