using BookStoreManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreManagement.DataAccessLayer
{
    public interface IBookStoreManagementDAL
    {
        public Task<bool> AddBook(Books book);
        public Task<bool> AddUser(Users userObj);
        public Task<bool> UpdateBook(Books bookObj);
        public Task<bool> UpdateUser(Users userObj);
        public Task<bool> DeleteUser(int userId);
        public Task<List<Books>> GetAllBooks();
        public Task<bool> AddTranscation(Transcations transcationsObj);
        public Task<List<Transcations>> GetAllTranscation();
        public Task<List<Users>> GetAllUsers();
        public Task<Transcations> GetFineDetailsBasedOnBookId(int transactionId, int bookId, int userId);
    }
}
