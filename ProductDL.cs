using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using BL;

namespace DL
{
    public class ProductDL
    {
        DBManager objDb = new DBManager();
        public DataTable GetAllProducts()
        {
            return objDb.ExecuteDatatable("select * from view_cat_pro");
        }
        public DataTable GetAllProducts(string catcode)
        {
            return objDb.ExecuteDatatable("select * from view_cat_pro where procat="+catcode+"");
        }


        public void SaveProduct(ProductBL objBL)
        {
            objDb.ExecuteNoneQuery("insert into product (proname,prostatus,procat,proprice,proimage) values ('" + objBL.proname + "' ,'" + objBL.prostatus + "', '" + objBL.procat + "', '" + objBL.proprice + "', '" + objBL.proimage + "')");
        }
        public void UpdateProduct(ProductBL objBL , bool UpdateImage)
        {
            if (UpdateImage)
            {
                objDb.ExecuteNoneQuery("update product set proname='" + objBL.proname + "', prostatus='" + objBL.prostatus + "',  procat=" + objBL.procat + ",  proprice='" + objBL.proprice + "', proimage='" + objBL.proimage + "' where procode=" + objBL.procode + "");
            }
            else
            {
                objDb.ExecuteNoneQuery("update product set proname='" + objBL.proname + "', prostatus='" + objBL.prostatus + "',  procat=" + objBL.procat + ",  proprice='" + objBL.proprice + "' where procode=" + objBL.procode + "");
            }

        }
    }
}