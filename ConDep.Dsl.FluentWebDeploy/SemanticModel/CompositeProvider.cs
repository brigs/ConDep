using System;
using System.Collections.Generic;
using ConDep.Dsl.FluentWebDeploy.Builders;
using ConDep.Dsl.FluentWebDeploy.Deployment;

namespace ConDep.Dsl.FluentWebDeploy.SemanticModel
{
	public abstract class CompositeProvider : IProvide
	{
		private readonly List<IProvide> _childProviders = new List<IProvide>();

		public IEnumerable<IProvide> ChildProviders { get { return _childProviders; } }

		public string SourcePath { get; set; }
		public virtual string DestinationPath { get; set; }

		public abstract bool IsValid(Notification notification);

		public int WaitInterval { get; set; }

		public abstract void Configure();

		protected void Configure(Action<ProviderCollectionBuilder> action)
		{
			action(new ProviderCollectionBuilder(_childProviders));
		}

        public DeploymentStatus Sync(WebDeployOptions webDeployOptions, DeploymentStatus deploymentStatus)
        {
            foreach (var childProvider in ChildProviders)
            {
                childProvider.Sync(webDeployOptions, deploymentStatus);
            }
            return deploymentStatus;
        }
	}
}