using System.Collections;
using System.Collections.Generic;

namespace Assets.Scripts.Common.Commands
{
	public abstract class CompositeCommand : Command, ICollection<ICommand>
	{
		public List<ICommand> _commands = new List<ICommand>();

		public List<ICommand> Commands => _commands;

		public IEnumerator<ICommand> GetEnumerator()
		{
			return _commands.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable)_commands).GetEnumerator();
		}

		public void Add(ICommand item)
		{
			_commands.Add(item);
		}

		public void Clear()
		{
			_commands.Clear();
		}

		public bool Contains(ICommand item)
		{
			return _commands.Contains(item);
		}

		public void CopyTo(ICommand[] array, int arrayIndex)
		{
			_commands.CopyTo(array, arrayIndex);
		}

		public bool Remove(ICommand item)
		{
			return _commands.Remove(item);
		}

		public int Count => _commands.Count;

		public bool IsReadOnly => ((ICollection<ICommand>)_commands).IsReadOnly;
	}
}