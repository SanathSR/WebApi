using BookStoreManagement.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreManagement.BusinessLayer
{
    public interface IBookStoreManagementBL
    {
        public Task<bool> AddBook(Books book);
        public Task<bool> AddUser(Users userObj);
        public Task<bool> UpdateBook(Books bookObj);
        public Task<bool> UpdateUser(Users userObj);
        public Task<bool> DeleteUser(int userId);
        public Task<List<Books>> GetAllBooks();
        public Task<bool> AddTranscation(Transcations transcationsObj);
        public Task<List<Transcations>> GetAllTranscation();
        public Task<int> GetBooksCountForRent();
        public Task<int> GetBooksCountForSale();
        public Task<List<Books>> GetBooksNonSelected();
        public Task<List<Users>> GetAllUsers();
        public Task<string> GetFineDetailsBasedOnBookId(int transactionId, int bookId, int userId);
    }
}
