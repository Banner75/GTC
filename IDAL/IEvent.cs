using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZGZY.IDAL
{
    public interface IEvent
    {
        void CalculationBonus(object obj);

        void DigInCome(object obj);
        /// <summary>
        /// 根据ID获取最后执行事件时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DateTime GetEventLastExecuteTimeByKey(string id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        void AddExecuteTimeError(string message, int state);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="id"></param>
        void UpdateExecuteTimeError(string message, int id);

        /// <summary>
        /// 扫描过期矿机
        /// </summary>
        void MachinePass();
        void UpdateMrcPrice();
        void CalculateJianDian(object obj);


    }
}
