using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommandsService.Models;

namespace CommandsService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _context;

        public CommandRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            command.PlatformId = platformId;

            _context.Commands.Add(command);
            _context.SaveChanges();
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
            {
                throw new ArgumentNullException(nameof(platform));
            }

            _context.Platforms.Add(platform);
            _context.SaveChanges();
        }

        public bool ExternalPlatformExists(int externalPlatformId)
        {
            return _context.Platforms.Any(p => p.ExternalID == externalPlatformId);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            var platforms = _context.Platforms.ToList();

            return platforms;
        }

        public Command? GetCommand(int platformId, int commandId)
        {
            var command = _context.Commands.Where(c => c.PlatformId == platformId && c.Id == commandId).FirstOrDefault();

            return command;
        }

        public IEnumerable<Command> GetCommandsForPlatform(int platformId)
        {
            var commands = _context.Commands.Where(c => c.PlatformId == platformId).OrderBy(c => c.Platform!.Name);

            return commands;
        }

        public bool PlatformExists(int platformId)
        {
            return _context.Platforms.Any(p => p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}