using System;
using ConDep.Dsl.FluentWebDeploy.SemanticModel;

namespace ConDep.Dsl.FluentWebDeploy.Builders
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
		    _source.LocalHost = true;
			return _syncBuilder;
		}

		public SyncBuilder LocalHost(Action<CredentialsBuilder> credentials)
		{
			_source.ComputerName = "127.0.0.1";
			var credBuilder = new CredentialsBuilder(_source.Credentials);
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

			var credBuilder = new CredentialsBuilder(_source.Credentials);
			credentials(credBuilder);
			return _syncBuilder;
		}
	}
}