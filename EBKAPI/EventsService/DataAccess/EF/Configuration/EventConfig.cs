﻿using EventsService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsService.DataAccess.EF.Configuration
{
    internal class EventConfig : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> entity)
        {
            entity.ToTable("Events");
            entity.Property(q => q.Code).IsRequired();
            entity.Property(q => q.Name).IsRequired();
            entity.Property(q => q.Image).HasDefaultValue(null);
        }
    }
}
