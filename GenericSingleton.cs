using System;
using System.Collections.Generic;
using System.Text;

namespace Gfi.Hub.XamarinForms.Models
{
    /// <summary>
	/// Singleton Pattern Template
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class GenericSingleton<T> where T : class
    {
        /// <summary>
        /// The synchronize object
        /// </summary>
        protected static readonly object syncObject = new object();

        /// <summary>
        /// The instance
        /// </summary>
        private static T obj = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericSingleton{T}"/> class.
        /// </summary>
        protected GenericSingleton()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static T Obj
        {
            get
            {
                if (obj == null)
                {
                    lock (syncObject)
                    {
                        if (obj == null)
                        {
                            obj = Activator.CreateInstance<T>();
                            OnInitialize?.Invoke(obj);
                        }

                    }
                }
                return obj;
            }
        }

        public static Action<T> OnInitialize;
    }
}
