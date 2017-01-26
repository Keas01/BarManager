using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BarManager.DL
{
    public class Base_DL : IDisposable
    {
        private BarManagerEntities _context = null;
        public  BarManagerEntities context
        {
            get
            {
                if (_context == null)
                {
                    _context = new BarManagerEntities();
                }
                return _context;
            }
        }

        public Base_DL()
        {
            _context = new BarManagerEntities();
        }

        public Base_DL(BarManagerEntities context)
        {
            _context = context;
        }

        #region IDisposable Implementation
        bool disposed = false;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }
        #endregion
    }
}
