using Microsoft.EntityFrameworkCore;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
namespace BooksDB
{
    public partial class Form1 : Form
    {

        // Scaffold-DbContext "Server=(localdb)\MSSQLLocalDB;Database=BookDB;Integrated Security=SSPI;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer 
        public Form1()
        {
            InitializeComponent();
            try
            {
                using (var db = new BookDbContext())
                {
                    Text = "Автори та книги";
                    checkBox1.Text = "Фільтрація";
                    dataGridView1.AutoGenerateColumns = false;
                    dataGridView1.Columns.Clear();
                    dataGridView1.ReadOnly = true;
                    dataGridView1.AllowUserToAddRows = false;
                    dataGridView1.AllowUserToDeleteRows = false;
                    dataGridView1.RowHeadersVisible = false;
                    dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    DataGridViewTextBoxColumn nameColumn = new DataGridViewTextBoxColumn();
                    nameColumn.DataPropertyName = "Name";
                    nameColumn.HeaderText = "Ім'я Автора";
                    nameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns.Add(nameColumn);

                    UpdateDataGridView();
                    UpdateListBox();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateDataGridView()
        {
            try
            {
                using (var db = new BookDbContext())
                {
                    var query = from b in db.Authors
                                select b;
                    dataGridView1.DataSource = query.ToList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateListBox()
        {
            try
            {
                using (var db = new BookDbContext())
                {
                    var query = from b in db.Books
                                select b;

                    if (checkBox1.Checked)
                    {
                        if (dataGridView1.CurrentRow == null)
                        {
                            listBox1.DataSource = null;
                            return;
                        }
                        var selectedAuthor = (Author?)dataGridView1.CurrentRow.DataBoundItem;
                        if (selectedAuthor != null)
                        {
                            query = query.Where(b => b.AuthorId == selectedAuthor.Id);
                        }
                    }
                    listBox1.DataSource = query.ToList();
                    listBox1.DisplayMember = "Title";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void додатиАвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form2 AddAuthorDialog = new Form2())
                {
                    AddAuthorDialog.SetDialogTitle("Додавання автора", "Введіть ім'я автора:");

                    if (AddAuthorDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var db = new BookDbContext())
                        {
                            Author newAuthor = new Author { Name = AddAuthorDialog.InputTextBox1 };
                            db.Authors.Add(newAuthor);
                            db.SaveChanges();
                        }
                        UpdateDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void видалитиАвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedAuthor = (Author?)dataGridView1.CurrentRow?.DataBoundItem;
                if (dataGridView1.RowCount == 0 || dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Список авторів порожній. Немає нікого для видалення!",
                                    "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var dialogResult = MessageBox.Show(
                $"Ви дійсно хочете видалити автора \"{selectedAuthor.Name}\" та ВСІ його книги? Цю дію неможливо скасувати.",
                "Підтвердження видалення",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
                );
                if (dialogResult == DialogResult.Yes)
                {
                    using (var db = new BookDbContext())
                    {
                        var authorInDb = db.Authors.Find(selectedAuthor.Id);

                        if (authorInDb != null)
                        {
                            db.Authors.Remove(authorInDb);
                            db.SaveChanges();
                        }
                    }

                    UpdateDataGridView();
                    UpdateListBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void редагуватиАвтораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form2 EditAuthorDialog = new Form2())
                {
                    EditAuthorDialog.SetDialogTitle("Редагування автора", "Введіть ім'я автора:");
                    var selectedAuthor = (Author?)dataGridView1.CurrentRow?.DataBoundItem;
                    EditAuthorDialog.InputTextBox1 = selectedAuthor != null ? selectedAuthor.Name : string.Empty;
                    if (dataGridView1.RowCount == 0 || dataGridView1.CurrentRow == null)
                    {
                        MessageBox.Show("Список авторів порожній. Немає нікого для редагування!",
                                        "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (EditAuthorDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (selectedAuthor != null)
                        {
                            using (var db = new BookDbContext())
                            {
                                var authorToUpdate = db.Authors.Find(selectedAuthor.Id);
                                if (authorToUpdate != null)
                                {
                                    authorToUpdate.Name = EditAuthorDialog.InputTextBox1;
                                    db.SaveChanges();
                                }
                            }
                        }
                        UpdateDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void додатиКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form2 AddBookDialog = new Form2())
                {
                    AddBookDialog.SetDialogTitle("Додавання книги", "Введіть назву книги:");
                    var selectedAuthor = (Author?)dataGridView1.CurrentRow?.DataBoundItem;

                    if (AddBookDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var db = new BookDbContext())
                        {
                            Book book = new Book
                            {
                                Title = AddBookDialog.InputTextBox1,
                                AuthorId = selectedAuthor.Id
                            };
                            db.Books.Add(book);
                            db.SaveChanges();
                        }
                        UpdateListBox();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void редагуватиКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (Form2 EditBookDialog = new Form2())
                {
                    EditBookDialog.SetDialogTitle("Редагування книги", "Введіть назву книги:");
                    var selectedBook = (Book?)listBox1.SelectedItem;

                    if (listBox1.Items.Count == 0 || listBox1.SelectedItem == null)
                    {
                        MessageBox.Show("Список книг порожній. Немає чого редагувати!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    EditBookDialog.InputTextBox1 = selectedBook != null ? selectedBook.Title : string.Empty;


                    if (EditBookDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (listBox1.SelectedIndex == -1)
                        {
                            MessageBox.Show("Виберіть книгу для редагування!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        if (EditBookDialog != null)
                        {
                            using (var db = new BookDbContext())
                            {
                                var bookToUpdate = db.Books.Find(selectedBook?.Id);
                                if (bookToUpdate != null)
                                {
                                    bookToUpdate.Title = EditBookDialog.InputTextBox1;
                                    db.SaveChanges();
                                }
                            }
                        }
                        UpdateDataGridView();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void видалитиКнигуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var selectedBook = (Book?)listBox1.SelectedItem;
                if (listBox1.Items.Count == 0 || listBox1.SelectedItem == null)
                {
                    MessageBox.Show("Список книг порожній. Немає чого видаляти!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var dialogResult = MessageBox.Show($"Видалити книгу \"{selectedBook?.Title}\"?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    using (var db = new BookDbContext())
                    {
                        var bookInDb = db.Books.Find(selectedBook?.Id);
                        if (bookInDb != null)
                        {
                            db.Books.Remove(bookInDb);
                            db.SaveChanges();
                        }
                    }
                    UpdateListBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
