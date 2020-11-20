using LibInterfaces.Server.Local;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIServer.WinForms
{
	public partial class FormStartServer : Form, IFormStartServer, IUIServerLocal
	{
		public FormStartServer()
		{
			InitializeComponent();

			m_ServerStateModel = new ServerStateModel();

			TextBoxIp.DataBindings.Add("Text", m_ServerStateModel, "Ip");
			TextBoxPort.DataBindings.Add("Text", m_ServerStateModel, "Port");
			TextBoxStatus.DataBindings.Add("Text", m_ServerStateModel, "ServerStatus", false, DataSourceUpdateMode.OnValidation);
		}



		//
		public Form GeneralForm => this;

		//
		public EventHandler<IServerState> EventServerStateShange
		{
			get => m_EventServerStateShanged;
			set => m_EventServerStateShanged = value;
		}

		//
		private EventHandler<IServerState> m_EventServerStateShanged;

		//
		private ServerStateModel m_ServerStateModel;



		//
		private void ButtonStartStop_Click(object sender, EventArgs e)
		{
			EventServerStateShange?.Invoke(this, m_ServerStateModel);
		}

		//
		public void ViewServerState(IServerState ServerState)
		{
			m_ServerStateModel.Ip = ServerState.Ip;
			m_ServerStateModel.Port = ServerState.Port;
			m_ServerStateModel.ServerStatus = ServerState.ServerStatus;

			Refresh();
		}

		//
		public override void Refresh()
		{
			TextBoxIp.Text = m_ServerStateModel.Ip;
			TextBoxPort.Text = m_ServerStateModel.Port;
			TextBoxStatus.Text = m_ServerStateModel.ServerStatus.ToString();

			base.Refresh();
		}
	}
}