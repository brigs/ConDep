using System;
using ConDep.WebDeploy.Dsl.SemanticModel;

namespace ConDep.WebDeploy.Dsl.Builders
{
	public class FromBuilder
	{
		private readonly Source _source;
		private readonly SyncBuilder _syncBuilder;

		public FromBuilder(Source source, SyncBuilder syncBuilder)
		{
			_source = source;
			_syncBuilder = syncBuilder;
		}

		public SyncBuilder LocalHost()
		{
			_source.ComputerName = "127.0.0.1";
			return _syncBuilder;
		}

		public SyncBuilder LocalHost(Action<CredentialsBuilder> credentials)
		{
			_source.ComputerName = "127.0.0.1";
			var credBuilder = new CredentialsBuilder(_source.CredentialsProvider);
			credentials(credBuilder);
			return _syncBuilder;
		}

		public SyncBuilder Server(string serverName)
		{
			_source.ComputerName = serverName;
			return _syncBuilder;
		}

		public SyncBuilder Server(string serverName, Action<CredentialsBuilder> credentials)
		{
			_source.ComputerName = serverName;

			var credBuilder = new CredentialsBuilder(_source.CredentialsProvider);
			credentials(credBuilder);
			return _syncBuilder;
		}
	}
}