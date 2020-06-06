using pan.kaikj.wxsupermarket.AdoModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pan.kaikj.wxsupermarket.bus
{
    /// <summary>
    /// 全局缓存数据
    /// </summary>
    public class CacheData
    {
        /// <summary>
        /// 所有class
        /// </summary>
        private static List<Mproductclass> _allProductClass;

        public static List<Mproductclass> allProductClass
        {

            get {
                if (_allProductClass==null)
                {
                    _allProductClass= new ProductBus().GetProductclassesBySupclassid(-1);
                }

                return _allProductClass;
            }

            set { _allProductClass = value; }

        }

        /// <summary>
        /// 所有推荐
        /// </summary>
        private static string _allRecommendPro;

        public static string allRecommendPro
        {

            get
            {
                if (_allRecommendPro == null)
                {
                    _allRecommendPro = new ProductBus().GetProductcListBySupClassId(1, 0, 1, 1, string.Empty);
                }

                return _allRecommendPro;
            }

            set { _allRecommendPro = value; }
        }


        /// <summary>
        /// 所有推荐(集合对象)
        /// </summary>
        private static List<Mproduct> _allRecommendProList;

        public static List<Mproduct> allRecommendProList
        {

            get
            {
                if (_allRecommendProList == null)
                {
                    _allRecommendProList = new ProductBus().GetAllProductcListBySupClassId(50, 0, 1, 1, string.Empty);
                }

                return _allRecommendProList;
            }

            set { _allRecommendProList = value; }
        }
    }
}