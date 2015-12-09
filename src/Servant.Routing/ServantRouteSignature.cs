using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servant.Routing
{
    public class ServantRouteSignature : IServantRouteSignature
    {
        private int level;

        public ServantRouteSignature(int level)
        {
            this.level = level;
        }

        public IServantRoutePathSegment[] Paths { get; set; }
    }
}
