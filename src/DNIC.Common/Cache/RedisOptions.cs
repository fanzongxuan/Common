using System;
using System.Collections.Generic;
using System.Text;

namespace DNIC.Common.Cache
{
    public class RedisOptions
    {
        /// <summary>
        /// is enabke
        /// </summary>
        public bool Enable { get; set; }

        /// <summary>
        /// The configuration used to connect to Redis.
        /// </summary>
        public string Configration { get; set; }

        /// <summary>
        /// The Redis instance name.
        /// </summary>
        public string InstanceName { get; set; }
    }
}
