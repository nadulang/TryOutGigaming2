﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NotificationService.Application.UseCases.Notifications.Request;
using NotificationService.Infrastructure.Persistences;

namespace NotificationService.Application.UseCases.Notifications.Queries.GetAll
{
    public class GetAllQueryHandler : IRequestHandler<GetAllQuery, GetAllDto>
    {
        private readonly NotificationContext _context;

        public GetAllQueryHandler(NotificationContext context)
        {
            _context = context;
        }

        public async Task<GetAllDto> Handle(GetAllQuery request, CancellationToken cancellationToken)
        {

            var not = await _context.Notifications.ToListAsync();
            var log = await _context.Logs.ToListAsync();

                var allnotifications = new List<NotifQueryDto>();

                foreach (var j in not)
                {
                    var alllogs = new List<LogsInput>();
                    var logs = log.Where(c => c.id == j.id);

                    foreach (var o in logs)
                    {
                        alllogs.Add(new LogsInput
                        {
                            notification_id = o.notification_id,
                            from = o.from,
                            read_at = DateTime.Now,
                            target = o.target
                        });
                    }

                    allnotifications.Add(new NotifQueryDto()
                    {
                        total = alllogs.Count,
                        read_count = allnotifications.Count,
                        notification = new NotificationInput()
                        {
                            id = j.id,
                            title = j.title,
                            message = j.message
                        },

                        logs = alllogs
                    });
                }

                return new GetAllDto
                {

                    message = "Success retrieving data",
                    success = true,
                    Data = allnotifications

                };

            

        }

    }
}
