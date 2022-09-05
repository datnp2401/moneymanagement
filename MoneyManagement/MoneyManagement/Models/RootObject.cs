using System;
using System.Collections.Generic;
using System.Text;

namespace MoneyManagement.Models
{
    public class RootObject
    {

    }

    public class Id
    {
        public string id { get; set; }
    }

    public class Updated
    {
        public DateTime dt { get; set; }
    }

    public class Category
    {
        public string scheme { get; set; }
        public string term { get; set; }
    }

    public class Title
    {
        public string type { get; set; }
        public string title { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class Name
    {
        public string name { get; set; }
    }

    public class Email
    {
        public string email { get; set; }
    }

    public class Author
    {
        public Name name { get; set; }
        public Email email { get; set; }
    }

    public class OpenSearchTotalResults
    {
        public string openrs { get; set; }
    }

    public class OpenSearchStartIndex
    {
        public string openstart { get; set; }
    }

    public class GsRowCount
    {
        public string count { get; set; }
    }

    public class GsColCount
    {
        public string count { get; set; }
    }

    public class Id2
    {
        public string id { get; set; }
    }

    public class Updated2
    {
        public DateTime dt { get; set; }
    }

    public class Category2
    {
        public string scheme { get; set; }
        public string term { get; set; }
    }

    public class Title2
    {
        public string type { get; set; }
        public string title { get; set; }
    }

    public class Content
    {
        public string type { get; set; }
        public string content { get; set; }
    }

    public class Link2
    {
        public string rel { get; set; }
        public string type { get; set; }
        public string href { get; set; }
    }

    public class GsCell
    {
        public string row { get; set; }
        public string col { get; set; }
        public string inputValue { get; set; }
        public string gsCell { get; set; }
    }

    public class Entry
    {
        public Id2 id { get; set; }
        public Updated2 updated { get; set; }
        public List<Category2> category { get; set; }
        public Title2 title { get; set; }
        public Content content { get; set; }
        public List<Link2> link { get; set; }
        public GsCell gscell { get; set; }
    }

    public class Feed
    {
        public string xmlns { get; set; }
        public string xmlnsopenSearch { get; set; }
        public string xmlnsbatch
        { get; set; }
        public string xmlnsgs
        { get; set; }
        public Id id { get; set; }
        public Updated updated { get; set; }
        public List<Category> category { get; set; }
        public Title title { get; set; }
        public List<Link> link { get; set; }
        public List<Author> author { get; set; }
        public OpenSearchTotalResults openSearchtotalResults
        { get; set; }
        public OpenSearchStartIndex openSearchstartIndex
        { get; set; }
        public GsRowCount gsrowCount
        { get; set; }
        public GsColCount gscolCount
        { get; set; }
        public List<Entry> entry { get; set; }
    }

    public class Root
    {
        public string version { get; set; }
        public string encoding { get; set; }
        public Feed feed { get; set; }
    }
}
