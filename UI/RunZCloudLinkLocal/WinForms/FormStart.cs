using LibInterfaces.Recipient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RunZCloudLinkLocal.WinForms
{
	public partial class FormStart : Form, IFormStart, IUIController
	{
		public FormStart()
		{
			InitializeComponent();

			m_ServerStateModel = new RecipientStateModel();

			TextBoxIp.DataBindings.Add("Text", m_ServerStateModel, "Ip");
			TextBoxPort.DataBindings.Add("Text", m_ServerStateModel, "Port");
			TextBoxStatus.DataBindings.Add("Text", m_ServerStateModel, "ServerStatus", false, DataSourceUpdateMode.OnValidation);
		}



		// *
		public Form GeneralForm => this;

		// *
		public EventHandler<IRecipientState> EventServerStateShange
		{
			get => m_EventServerStateShanged;
			set => m_EventServerStateShanged = value;
		}

		// *
		private EventHandler<IRecipientState> m_EventServerStateShanged;

		// *
		private readonly RecipientStateModel m_ServerStateModel;



		// *
		private void ButtonStartStop_Click(object sender, EventArgs e)
		{
			EventServerStateShange?.Invoke(this, m_ServerStateModel);
		}

		// *
		public void ViewServerState(IRecipientState ServerState)
		{
			m_ServerStateModel.Ip = ServerState.Ip;
			m_ServerStateModel.Port = ServerState.Port;
			m_ServerStateModel.ServerStatus = ServerState.ServerStatus;

			Refresh();
		}

		// *
		public override void Refresh()
		{
			TextBoxIp.Text = m_ServerStateModel.Ip;
			TextBoxPort.Text = m_ServerStateModel.Port;
			TextBoxStatus.Text = m_ServerStateModel.ServerStatus.ToString();

			base.Refresh();
		}
	}
}