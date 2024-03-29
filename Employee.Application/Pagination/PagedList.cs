﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool hasPervious => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            AddRange(items);
        }
        public static PagedList<T> GetPagedList(IQueryable<T> source, int pageNumber, int PageSize)
        {
            var count = source.Count();
            var items = source.Skip((pageNumber - 1) * PageSize).Take(PageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, PageSize);
        }
    }
}
