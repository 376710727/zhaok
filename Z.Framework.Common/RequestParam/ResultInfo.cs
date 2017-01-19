using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z.Framework.Common
{
    public class ResultInfo
    {
        /// <summary>
        /// 请求是否成功
        /// </summary>
        public bool IsSuccessed { set; get; }
        /// <summary>
        /// 错误代码 或堆栈异常信息
        /// </summary>
        public string ErrorCode { set; get; }
        /// <summary>
        /// 错误信息
        /// </summary>
        public string ErrorText { set; get; }
        /// <summary>
        /// 返回结果
        /// </summary>
        public object Value { set; get; }
        /// <summary>
        /// 返回的模型结果 
        /// </summary>
        public object ModelValue { set; get; }
        /// <summary>
        /// 返回的键值对结果
        /// </summary>
        public KeyValuePair<object, object> PairValue { set; get; }
        /// <summary>
        /// 异步请求标示
        /// </summary>
        public bool AsynRequest { set; get; }
    }
}
