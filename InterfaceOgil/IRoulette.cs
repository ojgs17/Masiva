using InterfaceOgil;
using System;
using System.Collections.Generic;


namespace Models
{
    public interface IRoulette : IService
    {
        public Roulette create()
        {
            Guid guid = Guid.NewGuid();
            //string str = 
            Roulette rouletteNew;
            rouletteNew = new Roulette();
            rouletteNew.DateOpen = DateTime.UtcNow;
            rouletteNew.IsOpen = true;
            rouletteNew.Id= guid.ToString();



            return rouletteNew;
        }

        public Roulette Find(string Id);

        public Roulette Open(string Id);
        public Roulette Close(string Id);

        public Roulette Bet(string Id, string UserId, int position, double money);

        public List<Roulette> GetAll();
    }
}
