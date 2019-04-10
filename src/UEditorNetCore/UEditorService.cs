using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UEditorNetCore.Handlers;
using Microsoft.AspNetCore.Hosting;

namespace UEditorNetCore
{
    /// <summary>
    /// 
    /// </summary>
    public class UEditorService
    {
        private UEditorActionCollection actionList;

        /// <summary>
        /// /
        /// </summary>
        /// <param name="env"></param>
        /// <param name="actions"></param>
        public UEditorService(IHostingEnvironment env, UEditorActionCollection actions)
        {
            Config.WebRootPath = env.WebRootPath;
            actionList = actions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public void DoAction(HttpContext context)
        {
            var action = context.Request.Query["action"];
            if (actionList.ContainsKey(action))
                actionList[action].Invoke(context);
            else
                new NotSupportedHandler(context).Process();
        }
    }
}
