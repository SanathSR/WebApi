using BookStoreManagement.CustomExceptions;
using BookStoreManagement.DataAccessLayer;
using BookStoreManagement.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreManagement.BusinessLayer
{
    public class BookStoreManagementBL : IBookStoreManagementBL
    {
        private readonly IBookStoreManagementDAL _Repository;

        public BookStoreManagementBL(IBookStoreManagementDAL bookStoreManagementDAL)
        {
            _Repository = bookStoreManagementDAL;
        }

        public async Task<bool> AddBook(Books bookObj)
        {
            bookObj.AvilableFor = bookObj.AvilableFor.ToLower();
            return await _Repository.AddBook(bookObj);
        }

        public async Task<bool> AddUser(Users userObj)
        {
            userObj.IsDeleted = "no";
            return await _Repository.AddUser(userObj);
        }

        public async Task<bool> UpdateBook(Books bookObj)
        {
            bookObj.AvilableFor = bookObj.AvilableFor.ToLower();
            return await _Repository.UpdateBook(bookObj);
        }

        public async Task<bool> UpdateUser(Users userObj)
        {
            userObj.IsDeleted = "no";
            return await _Repository.UpdateUser(userObj);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return await _Repository.DeleteUser(userId);
        }

        public async Task<List<Books>> GetAllBooks()
        {
            return await _Repository.GetAllBooks();
        }

        public async Task<bool> AddTranscation(Transcations transcationsObj)
        {
            transcationsObj.TranscationAvailedAs = transcationsObj.TranscationAvailedAs.ToLower();

            return await _Repository.AddTranscation(transcationsObj);
        }

        public async Task<List<Transcations>> GetAllTranscation()
        {
            return await _Repository.GetAllTranscation();
        }

        public async Task<int> GetBooksCountForRent()
        {
            List<Books> allBooksList = await _Repository.GetAllBooks();
            int count = 0;
            foreach (Books books in allBooksList)
            {
                if(Convert.ToString(books.AvilableFor) == "rent")
                {
                    count++;
                }
            }
            return count;
        }
        public async Task<int> GetBooksCountForSale()
        {
            List<Books> allBooksList = await _Repository.GetAllBooks();
            int count = 0;
            foreach (Books books in allBooksList)
            {
                if (Convert.ToString(books.AvilableFor) == "sale")
                {
                    count++;
                }
            }
            return count;
        }

        public async Task<List<Books>> GetBooksNonSelected()
        {
            List<Books> allBooksList = await _Repository.GetAllBooks();
            List<Transcations> allTranscationsList = await _Repository.GetAllTranscation();

            List<Books> nonSelectedBooksList = new List<Books>();

            foreach (Books book in allBooksList)
            {
                foreach (Transcations transcation in allTranscationsList)
                {
                    if(book.BookId == transcation.TranscationBookId)
                    {
                        nonSelectedBooksList.Add(book);
                    }
                }
            }
            return nonSelectedBooksList;
        }

        public async Task<List<Users>> GetAllUsers()
        {
            List<Users> allUsersList = await _Repository.GetAllUsers();
            List<Users> nonDeletedUsers = new List<Users>();

            foreach (Users user in allUsersList)
            {
                if(user.IsDeleted == "no")
                {
                    nonDeletedUsers.Add(user);
                }
            }

            if(nonDeletedUsers.Count <= 0)
            {
                throw new NoDataPresentException("There are no data in the database");
            }
            else
            {
                return nonDeletedUsers;
            }
        }


        public async Task<string> GetFineDetailsBasedOnBookId(int transactionId, int bookId, int userId)
        {
            Transcations transactions = await _Repository.GetFineDetailsBasedOnBookId(transactionId, bookId, userId);

            System.TimeSpan returnDateDifference = DateTime.Now.Subtract(transactions.DateToReturn);

            if (returnDateDifference.TotalDays > 0)
            {
                int fine = (int)(returnDateDifference.TotalDays * 10 * transactions.TranscationQuantity);
                return "Your fine is " + fine + " for holding it for " + (int)returnDateDifference.TotalDays + " days";
            }
            else
            {
                return "No fine";
            }

        }

    }
}
