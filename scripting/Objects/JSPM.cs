﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Jurassic;
using Jurassic.Library;
using iconnect;

namespace scripting.Objects
{
    class JSPM : ObjectInstance
    {
        public IPrivateMsg _PM { get; set; }

        public JSPM(ObjectInstance prototype, IPrivateMsg pm)
            : base(prototype.Engine, ((ClrFunction)prototype.Engine.Global["PM"]).InstancePrototype)
        {
            this._PM = pm;
            this.PopulateFunctions();
        }

        protected override string InternalClassName
        {
            get { return "PM"; }
        }

        internal JSPM(ScriptEngine eng)
            : base(eng)
        {
            this.PopulateFunctions();
        }

        [JSFunction(Name = "contains", IsWritable = false, IsEnumerable = true)]
        public bool Contains(object a)
        {
            if (a != null)
                if (!(a is Undefined) && !(a is Null))
                    return this._PM.Contains(a.ToString());

            return false;
        }

        [JSFunction(Name = "remove", IsWritable = false, IsEnumerable = true)]
        public void Remove(object a)
        {
            if (a != null)
                if (!(a is Undefined) && !(a is Null))
                    this._PM.Remove(a.ToString());
        }

        [JSFunction(Name = "replace", IsWritable = false, IsEnumerable = true)]
        public void Replace(object a, object b)
        {
            if (a != null)
                if (!(a is Undefined) && !(a is Null))
                    if (b != null)
                        if (!(b is Undefined) && !(b is Null))
                            this._PM.Replace(a.ToString(), b.ToString());
        }
    }
}
