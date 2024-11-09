﻿using Library.IBookAuthorRepoistory.cs;
using Library.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Repository
{
    public class BookAuthorRepository:IBookAuthorRepository
    {
        private readonly LibraryContext _dbContext;
        public BookAuthorRepository(LibraryContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IList<BookAuthor>> GetBookAuthorsAsync()
        {
            if (_dbContext == null)
            {
                return  null;
            }
            return await _dbContext.BookAuthors.ToListAsync();
        }
        public async Task<BookAuthor> GetBookAuthorAsync(int Id)
        {
            if (_dbContext == null)
            {
                return null;
            }
            return await _dbContext.BookAuthors.FindAsync(Id);
        }
        public async Task<int> CreateBookAuthorAsync(BookAuthor bookAuthor)
        {
            if(_dbContext == null)
            {
                return 0;
            }
            _dbContext.BookAuthors.Add(bookAuthor);
            return await _dbContext.SaveChangesAsync();
        }
        public async Task<BookAuthor> UpdateBookAuthorAsync(int id, BookAuthor bookAuthor)
        {
            if (_dbContext == null)
            {
                return null;
            }
            _dbContext.Entry(bookAuthor).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return bookAuthor;
        }
        public async Task<int> DeleteBookAuthorAsync(int Id)
        {
            if (_dbContext == null)
            {
                return 0;
            }
            BookAuthor bookAuthor =await _dbContext.BookAuthors.FindAsync(Id);
            if(bookAuthor == null)
            {
                return -1;
            }
             _dbContext.BookAuthors.Remove(bookAuthor);
            await _dbContext.SaveChangesAsync();
            return 1;
        }

    }
}