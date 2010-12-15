using System;
using Microsoft.TeamFoundation.Client;
using Sep.Git.Tfs.Core.TfsInterop;

namespace Sep.Git.Tfs.VsCommon
{
    public partial class TfsHelper : ITfsHelper
    {
        private TeamFoundationServer server;

        public string TfsClientLibraryVersion
        {
            get { return typeof(TeamFoundationServer).Assembly.GetName().Version.ToString() + " (MS)"; }
        }

        public bool ShowCheckinDialog(IWorkspace workspace, IPendingChange[] pendingChanges)
        {
            throw new NotImplementedException();
        }

        private void UpdateServer()
        {
            if (string.IsNullOrEmpty(Url))
            {
                server = null;
            }
            else
            {
                server = new TeamFoundationServer(Url, new UICredentialsProvider());
                server.EnsureAuthenticated();
            }
        }

        private TeamFoundationServer Server
        {
            get
            {
                return server;
            }
        }
    }
}