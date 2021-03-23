using BookStoreManagement.CustomExceptions;
using BookStoreManagement.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreManagement.DataAccessLayer
{
    public class BookStoreManagementDAL : IBookStoreManagementDAL
    {
        private readonly BookStoreManagementDbContext _Context;

        public BookStoreManagementDAL(BookStoreManagementDbContext bookStoreManagementDbContext)
        {
            _Context = bookStoreManagementDbContext;
        }

        public async Task<bool> AddBook(Books bookObj)
        {
            if (await _Context.Books.FirstOrDefaultAsync(x => Convert.ToString(x.BookName) == Convert.ToString(bookObj.BookName)) != null)
            {
                throw new DuplicateBookNameException("Same book is already present in database");
            }
            else
            {
                try
                {
                    int rows = 0;
                    _Context.Books.Add(bookObj);
                    rows = await _Context.SaveChangesAsync();
                    if (rows == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new SqlExceptions("Server Error Occured", ex);
                }
            }
        }

        public async Task<bool> AddUser(Users userObj)
        {
            if (await _Context.Users.FirstOrDefaultAsync(x => Convert.ToString(x.UserName) == Convert.ToString(userObj.UserName)) != null)
            {
                throw new DuplicateUserNameException("User is already present in database");
            }
            else
            {
                try
                {
                    int rows = 0;
                    _Context.Users.Add(userObj);
                    rows = await _Context.SaveChangesAsync();
                    if (rows == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {

                    throw new SqlExceptions("Server Error Occured", ex);
                }
            }
        }

        public async Task<bool> UpdateBook(Books bookObj)
        {
            Books isBookPresent = await _Context.Books.FirstOrDefaultAsync(x => Convert.ToString(x.BookId) == Convert.ToString(bookObj.BookId));
            if (isBookPresent == null)
            {
                throw new BookNotFoundException("No book found for this id");
            }
            else
            {
                try
                {
                    isBookPresent.BookId = bookObj.BookId;
                    isBookPresent.BookName = bookObj.BookName;
                    isBookPresent.Author = bookObj.Author;
                    isBookPresent.Publisher = bookObj.Publisher;
                    isBookPresent.Cost = bookObj.Cost;
                    isBookPresent.AvilableFor = bookObj.AvilableFor;
                    isBookPresent.Quantity = bookObj.Quantity;

                    int rows = 0;
                    rows = _Context.SaveChanges();
                    if (rows == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new SqlExceptions("Server Error Occured", ex);
                }
            }
        }

        public async Task<bool> UpdateUser(Users userObj)
        {
            Users isUserPresent = await _Context.Users.FirstOrDefaultAsync(x => Convert.ToString(x.UserId) == Convert.ToString(userObj.UserId));
            if (isUserPresent == null)
            {
                throw new UserNotFoundException("No user found for this id");
            }
            else
            {
                try
                {
                    isUserPresent.UserName = userObj.UserName;
                    isUserPresent.UserId = userObj.UserId;
                    isUserPresent.EmailId = userObj.EmailId;
                    isUserPresent.IsDeleted = userObj.IsDeleted;

                    int rows = 0;
                    rows = _Context.SaveChanges();
                    if (rows == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new SqlExceptions("Server Error Occured", ex);
                }
            }
        }

        public async Task<bool> DeleteUser(int userId)
        {

            Users isUserPresent = await _Context.Users.FirstOrDefaultAsync(x => Convert.ToString(x.UserId) == Convert.ToString(userId));
            if (isUserPresent == null)
            {
                throw new DuplicateBookNameException("There is no such user with the id");
            }
            else
            {
                try
                {
                    int rows = 0;

                    isUserPresent.IsDeleted = "yes";

                    rows = _Context.SaveChanges();
                    if (rows == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    throw new SqlExceptions("Server Error Occured", ex);
                }
            }
        }

        public async Task<List<Users>> GetAllUsers()
        {
            try
            {
                List<Users> listOfAllUsers = await _Context.Users.ToListAsync();
                return listOfAllUsers;
            }
            catch (Exception ex)
            {
                throw new SqlExceptions("Server Error Occured", ex);
            }
        }

        public async Task<List<Books>> GetAllBooks()
        {
            try
            {
                List<Books> listOfAllBooks = await _Context.Books.ToListAsync();
                return listOfAllBooks;
            }
            catch (Exception ex)
            {
                throw new SqlExceptions("Server Error Occured", ex);
            }
        }

        public async Task<bool> AddTranscation(Transcations transcationsObj)
        {
            if (!(transcationsObj.TranscationQuantity > 0))
            {
                throw new QuantityException("Quantity cannot be 0");
            }
            else
            {

                Books isBookPresent = await _Context.Books.FirstOrDefaultAsync(x => Convert.ToString(x.BookId) == Convert.ToString(transcationsObj.TranscationBookId));

                /*if (isBookPresent != null)
                {
                    throw new InvalidBookIdException("There is no book for this id");
                }*/
                if (await _Context.Users.FirstOrDefaultAsync(x => Convert.ToString(x.UserId) == Convert.ToString(transcationsObj.TranscationUserId)) == null)
                {
                    throw new InvalidUserIdException("There is no user for this id");
                }
                else if (isBookPresent == null)
                {
                    throw new InvalidBookIdException("There is no book for this id");
                }
                else
                {
                    if (!(isBookPresent.Quantity >= transcationsObj.TranscationQuantity))
                    {
                        throw new QuantityException("There is no enough quantity");
                    }
                    else
                    {
                        if (Convert.ToString(isBookPresent.AvilableFor) == Convert.ToString(transcationsObj.TranscationAvailedAs))
                        {
                            try
                            {
                                int rows = 0;
                                _Context.Transcations.Add(transcationsObj);
                                rows = await _Context.SaveChangesAsync();

                                if (rows == 0)
                                {
                                    return false;
                                }
                                else
                                {
                                    isBookPresent.Quantity -= transcationsObj.TranscationQuantity;
                                    await UpdateBook(isBookPresent);
                                    return true;
                                }
                            }
                            catch (Exception ex)
                            {
                                throw new SqlExceptions("Server error occured", ex);
                            }
                        }
                        else
                        {
                            throw new InvalidAvilableForException("Avilable for is not matching");
                        }
                    }

                }
            }
        }

        public async Task<List<Transcations>> GetAllTranscation()
        {
            try
            {
                List<Transcations> listOfAllTranscation = await _Context.Transcations.ToListAsync();
                return listOfAllTranscation;
            }
            catch (Exception ex)
            {
                throw new SqlExceptions("Server Error Occured", ex);
            }
        }

        public async Task<Transcations> GetFineDetailsBasedOnBookId(int transactionId, int bookId, int userId)
        {
            Transcations transaction = await _Context.Transcations.FirstOrDefaultAsync(x => x.TranscationId == transactionId);
            if (transaction == null || transaction.TranscationUserId != userId || transaction.TranscationBookId != bookId)
            {
                throw new TransactionIdInvalidException("The Transaction details is wrong");
            }
            else if (transaction.TranscationAvailedAs.CompareTo("rent") != 0)
            {
                throw new BookNotAvailableForThatPurposeException("This book was not on Rent so it cant be returned");
            }
            else
            {
                try
                {
                    Books book = await _Context.Books.FindAsync(transaction.TranscationBookId);
                    book.Quantity += transaction.TranscationQuantity;
                    await UpdateBook(book);

                    return transaction;
                }
                catch (Exception ex)
                {
                    throw new NoDataPresentException("There is no transaction for this book id and user id", ex);
                }
            }
        }
    }
}
