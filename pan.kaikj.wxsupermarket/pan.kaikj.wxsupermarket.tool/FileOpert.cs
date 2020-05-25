/****************************************************************************
*Copyright (c) 2018  All Rights Reserved.
*CLR版本： 4.0.30319.42000
*机器名称：F0T0R88BCEOHZJQ
*公司名称：
*命名空间：weiXinGongZhongHao.Tool
*文件名：  FileOpert
*版本号：  V1.0.0.0
*唯一标识：56fd0e37-4027-4c98-aaab-8606cffa099b
*当前的用户域：F0T0R88BCEOHZJQ
*创建人：  Administrator
*电子邮箱：1315597862@qq.com
*创建时间：2018/9/2 20:11:23

*描述：
*
*=====================================================================
*修改标记
*修改时间：2018/9/2 20:11:23
*修改人： Administrator
*版本号： V1.0.0.0
*描述：
*
*****************************************************************************/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;

namespace pan.kaikj.wxsupermarket.tool
{
    /// <summary>
    /// FileOpert 文件相关操作
    /// </summary>
    public static class FileOpert
    {
        /// <summary>
        /// 检查文件夹是否已经存在
        /// </summary>
        /// <param name="folderName">文件夹的物理路径</param>
        /// <returns></returns>
        public static bool CheckDirectoryIsExists(string folderName)
        {
            return Directory.Exists(folderName);
        }

        /// <summary>
        /// 检查文件夹是否已经存在
        /// </summary>
        /// <param name="folderName">文件夹的物理路径</param>
        /// <returns></returns>
        public static bool CheckDirectoryIsExists(string folderName, bool isCreate)
        {
            bool isExists = Directory.Exists(folderName);

            if (!isExists && isCreate)
            {
                Directory.CreateDirectory(folderName);
            }

            return isExists;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="folderName">文件夹的物理路径</param>
        /// <returns></returns>
        public static bool CreateDirectory(string folderName)
        {
            if (Directory.Exists(folderName))
            {
                //文件夹已经存在
                return true;
            }
            else
            {
                try
                {
                    Directory.CreateDirectory(folderName);
                    //创建成功
                    return true;
                }
                catch (Exception)
                {
                    //创建失败 ,原因： ex.Message
                    return false;
                }
            }
        }

        /// <summary>
        /// 检查文件是否已经存在
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static bool CheckFileIsExists(string filePath)
        {
            return System.IO.File.Exists(filePath);
        }

        /// <summary>
        /// 检查文件是否已经存在
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="isCreate">如果文件不存在，是否创建文件</param>
        /// <returns></returns>
        public static bool CheckFileIsExists(string filePath, bool isCreate)
        {
            bool isExists = System.IO.File.Exists(filePath);
            if (!isExists && isCreate)
            {
                CreateFile(filePath);
            }
            return isExists;
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="filePath">文件的物理路径+名称</param>
        /// <returns></returns>
        public static bool CreateFile(string filePath)
        {
            if (System.IO.File.Exists(filePath))
            {
                //判断新建的文件是否已经存在
                throw new Exception("文件已经存在");
            }

            try
            {
                System.IO.File.Create(filePath);
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        /// <summary>
        /// 写文件（被写内容为一个字符串集合） 采用默认utf-8编码
        /// </summary>
        /// <param name="filePath">文件物理地址</param>
        /// <param name="valueList">数据集合</param>
        public static void WriteFile(string filePath, string[] valueList)
        {
            File.AppendAllLines(filePath, valueList, Encoding.UTF8);
        }

        /// <summary>
        /// 写文件（被写内容为一个字符串集合）
        /// </summary>
        /// <param name="filePath">文件物理地址</param>
        /// <param name="valueList">数据集合</param>
        /// <param name="encoding">编码方式</param>
        public static void WriteFile(string filePath, string[] valueList, Encoding encoding)
        {
            File.AppendAllLines(filePath, valueList, encoding);
        }

        /// <summary>
        /// 写文件（被写内容为一个字符串） 采用默认utf-8编码
        /// </summary>
        /// <param name="filePath">文件物理地址</param>
        /// <param name="value">待写内容</param>       
        /// <param name="isAddTime">是否在前面添加时间搓</param>
        public static void WriteFile(string filePath, string value, bool isAddTime)
        {
            value = (isAddTime ? System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss :") : "") + value + "\n";
            File.AppendAllText(filePath, value, Encoding.UTF8);
            //System.IO.StreamWriter streamWriter = System.IO.File.AppendText(filePath);
            //streamWriter.WriteLine(value, Encoding.GetEncoding("utf-8"));
            //streamWriter.Close();
            //streamWriter.Dispose();
        }

        /// <summary>
        /// 写文件（被写内容为一个字符串）
        /// </summary>
        /// <param name="filePath">文件物理地址</param>
        /// <param name="value">待写内容</param>
        /// <param name="isAddTime">是否在前面添加时间搓</param>
        /// <param name="encoding">编码方式</param>
        public static void WriteFile(string filePath, string value, bool isAddTime, Encoding encoding)
        {
            value = (isAddTime ? System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss :") : "") + value + "\n";
            File.AppendAllText(filePath, value, encoding);
           //// System.IO.StreamWriter streamWriter = System.IO.File.AppendText(filePath);
           //// streamWriter.WriteLine(value, encoding);
        }


        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="file"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
        public static string UploadImg(HttpPostedFileBase file, string dir,out string savePath)
        {
            savePath = string.Empty;
            try
            {
                string Image_Path = null;          //保存的文件
                Dictionary<string, string> DicInfo = new Dictionary<string, string>();  //返回的文件信息

                //判断上传文件的类型
                string fileName = Path.GetFileName(file.FileName); //获取文件名
                string fileExt = Path.GetExtension(fileName);      //获取扩展名

                if (fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".png")
                {
                    //创建文件夹
                    FileOpert.CreateDirectory(dir);
                    //需要对上传的文件进行重命名
                    string newfileName = Guid.NewGuid().ToString();
                    //构建文件完整路径
                    string fullDir = dir + newfileName + fileExt;
                    file.SaveAs(fullDir);  //保存文件  
                    savePath = fullDir;
                    return "";
                }
                else
                {
                    return "图片格式不支持！";
                }
            }
            catch (Exception ex)
            {
                return "图片上传失败！"+ ex.Message;
            }
        }
    }
}
