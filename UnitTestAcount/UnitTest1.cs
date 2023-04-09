using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using QLNS_TinhVanSoftWare;
using QLNS_TinhVanSoftWare.DataAccessLayer;
using QLNS_TinhVanSoftWare.BusinessLogicLayer;
using System.Data.SqlClient;
using System.Data;

namespace UnitTestAcount
{
    [TestClass]
    public class UnitTest1
    {
        private string constr = @"Data Source=DESKTOP-96D4EUK\ADMIN;Initial Catalog=QuanLyNhanVien;Integrated Security=True";
        TaiKhoanDAL c = new TaiKhoanDAL();
        [TestMethod]
        public void Test_update_acount()
        {
            TaiKhoanDAL c = new TaiKhoanDAL();

            // Act
            bool result = c.update("nv1", "diu12345", "Dùng", "Q00001");

            // Assert
            Assert.IsFalse(result);

            // Verify that the record has been updated in the database
            using (SqlConnection cnn = new SqlConnection(constr))
            {
                cnn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT s_Tinhtrang FROM tbl_TaiKhoan WHERE s_Taikhoan = 'nv1'", cnn))
                {
                    string tinhTrang = (string)cmd.ExecuteScalar();
                    Assert.AreEqual("Dùng", tinhTrang);
                }
            }
        }
        [TestMethod]
        public void TestMethod_Update_AcountCode_Does_Not_Exist()
        {
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

            int expected = -2; // Tên tài khoản không được trùng
            int actual = taiKhoanBLL.update("nv9", "diu12345", "Dùng", "Q00001");

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Test_delete_acount()
        {
            // Arrange
            string existingAccount = "NV00001"; // Thay bằng tên tài khoản tồn tại trong cơ sở dữ liệu

            // Act
            bool result = c.delete(existingAccount);

            // Assert
            Assert.IsFalse(result);

        }
        [TestMethod]
        public void Test_searchByName_acount1()
        {
            string existingKeyword = "nv3"; // Thay bằng từ khóa tồn tại trong dữ liệu

            // Act
            DataTable result = c.searchByName(existingKeyword);

            // Assert
            // test tìm kiếm tìm thấy tài khoản
            Assert.IsTrue(result.Rows.Count > 0);

        }
       /* [TestMethod]
        public void Test_searchByName_acount2()
        {
            string existingKeyword = "manh"; // Thay bằng từ khóa không tồn tại trong dữ liệu

            // Act
            DataTable result = c.searchByName(existingKeyword);

            // Assert
            // test tìm kiếm không tìm thấy tài khoản
            Assert.IsTrue(result.Rows.Count = 0);

        }
*/
        [TestMethod]
        public void TestMethod_Insert_Acount_Successfully()
        {

            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();


            int expected = 1; //true

            int actual = taiKhoanBLL.insert("TK0923", "nv9", "nv00009", "Dùng", "NV00009", "Q00002");

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_InsertAcount_DoesNotExist()
        {
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL();

            int expected = -3; //Mật khẩu phải có 6 ký tự trở lên
            int actual = taiKhoanBLL.insert("TK0922", "nv", "nv", "Dùng", "NV00009", "Q00002");

            Assert.AreEqual(expected, actual);
        }
    }
}



   


