using System;
using System.IO;
using System.Windows.Forms;

namespace FileBrowser
{
    public partial class FileBrowser : Form
    {
        private string rootDirectory;
        private TreeNode currentDirectoryNode;
        public FileBrowser()
        {
            InitializeComponent();
            // 因为 C 盘容易出现权限问题，所以以 D 盘为根目录...
            rootDirectory = "D:"; // 根目录路径
            PopulateTreeView(rootDirectory, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 设置窗口布局
            splitContainer1.Dock = DockStyle.Fill;
            // 设置树形视图
            treeView1.Dock = DockStyle.Fill;
            treeView1.AfterSelect += treeView1_AfterSelect;
            // 设置列表视图
            listView1.Dock = DockStyle.Fill;
            listView1.View = View.Details;
            listView1.Columns.Add("名称");
            listView1.Columns.Add("类型");
            listView1.DoubleClick += listView1_DoubleClick;


            splitContainer1.Panel1.Controls.Add(treeView1);
            splitContainer1.Panel2.Controls.Add(listView1);
            Controls.Add(splitContainer1);

        }

        private void PopulateTreeView(string directory, TreeNode parentNode)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(directory);
            TreeNode directoryNode = new TreeNode(directoryInfo.Name);

            if (parentNode == null)
            {
                treeView1.Nodes.Add(directoryNode);
            }
            else
            {
                parentNode.Nodes.Add(directoryNode);
            }

            if (currentDirectoryNode == null)
            {
                currentDirectoryNode = directoryNode;
            }

            try
            {
                foreach (var dir in directoryInfo.GetDirectories())
                {
                    PopulateTreeView(dir.FullName, directoryNode);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // 忽略无法访问的文件夹
            }
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1.SelectedNode = e.Node;
            string selectedPath = GetFullPath(e.Node);

            // 清空列表视图
            listView1.Items.Clear();

            DirectoryInfo directoryInfo = new DirectoryInfo(selectedPath);

            foreach (var dir in directoryInfo.GetDirectories())
            {
                ListViewItem item = new ListViewItem(dir.Name);
                item.SubItems.Add("文件夹");
                listView1.Items.Add(item);
            }

            foreach (var file in directoryInfo.GetFiles())
            {
                ListViewItem item = new ListViewItem(file.Name);
                item.SubItems.Add("文件");
                listView1.Items.Add(item);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedPath = GetFullPath(treeView1.SelectedNode) + "\\" + listView1.SelectedItems[0].Text;
                if (Path.GetExtension(selectedPath).ToLower() == ".txt")
                {
                    try
                    {
                        using (StreamReader sr = new StreamReader(selectedPath))
                        {
                            MessageBox.Show(sr.ReadToEnd(), "File Content");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error reading the file: " + ex.Message, "Error");
                    }
                }
            }
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string selectedItem = listView1.SelectedItems[0].Text;
                string selectedPath = GetFullPath(treeView1.SelectedNode) + "\\" + selectedItem;

                if (Directory.Exists(selectedPath))
                {
                    // 清空列表视图
                    listView1.Items.Clear();

                    // 更新树形视图
                    TreeNode selectedNode = treeView1.SelectedNode;
                    selectedNode.Nodes.Clear();
                    PopulateTreeView(selectedPath, selectedNode);

                    // 显示文件夹内容
                    DirectoryInfo directoryInfo = new DirectoryInfo(selectedPath);
                    foreach (var dir in directoryInfo.GetDirectories())
                    {
                        ListViewItem item = new ListViewItem(dir.Name);
                        item.SubItems.Add("文件夹");
                        listView1.Items.Add(item);
                    }
                    foreach (var file in directoryInfo.GetFiles())
                    {
                        ListViewItem item = new ListViewItem(file.Name);
                        item.SubItems.Add("文件");
                        listView1.Items.Add(item);
                    }
                    // 刷新树形视图
                    UpdateTreeView();
                }
            }
        }


        private string GetFullPath(TreeNode node)
        {
            if (node == null)
                return rootDirectory;

            string path = node.Text;
            TreeNode currentNode = node;

            while (currentNode.Parent != null)
            {
                currentNode = currentNode.Parent;
                path = currentNode.Text + "\\" + path;
            }

            return path;
        }

        private void UpdateTreeView()
        {
            treeView1.BeginUpdate();
            treeView1.Nodes.Clear();
            PopulateTreeView(rootDirectory, null);

            if (currentDirectoryNode != null)
            {
                treeView1.SelectedNode = currentDirectoryNode;
                currentDirectoryNode.Expand();
            }

            treeView1.EndUpdate();
        }

    }
}
