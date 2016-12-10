using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPod.DAL
{
    public class MyPodRepository
    {
        public MyPodContext Context { get; set; }
        public MyPodRepository(MyPodContext _context)
        {
            Context = _context;
        }

        public MyPodRepository()
        {
            Context = new MyPodContext();
        }

    }
}