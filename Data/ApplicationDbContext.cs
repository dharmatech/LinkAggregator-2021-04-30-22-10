using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LinkAggregator.Models;

namespace LinkAggregator.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Link> Link { get; set; }

        public DbSet<Vote> Vote { get; set; }

        public DbSet<Comment> Comment { get; set; }

        public DbSet<CommentVote> CommentVote { get; set; }
    }
}
