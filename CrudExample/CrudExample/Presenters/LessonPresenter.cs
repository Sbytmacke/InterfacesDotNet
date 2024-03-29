﻿using CrudExample.Models;

namespace CrudExample.Presenters
{
    class LessonPresenter : IPresenter<Lesson>
    {
        private MainWindow view;
        private LessonDAO lessonDAO;

        public LessonPresenter(MainWindow view)
        {
            this.view = view;
            this.lessonDAO = new LessonDAO();
            Update();
        }

        public void AddNewItem()
        {
            try
            {
                string number = view.GetNumber();
                string subject = view.GetSubject();
                Lesson lesson = new Lesson(subject, number);

                // Esto para guardar el fichero con los datos: lessonDAO.AddItem(lesson);
                view.AddItemToList(lesson);
            }
            catch
            {
                view.DisplayErrorMessage("Couldn't add this item");
                Update();
            }

        }

        public void DeleteItem()
        {
            try
            {
                int index = view.GetSelectedItemIndex();

                // Esto para borrar el fichero con los datos:  lessonDAO.DeleteItem(index);
                view.DeleteItem();
            }
            catch
            {
                view.DisplayErrorMessage("Couldn't delete this item");
                Update();
            }
        }

        public void Update()
        {
            view.UpdateItemList(lessonDAO.GetData());
        }

        public void BrowseItem()
        {
            try
            {
                int index = view.GetSelectedItemIndex();
            }
            catch
            {
                view.DisplayErrorMessage("Couldn't browse this item");
                Update();
            }
        }

        public void EditItem()
        {
            try
            {
                int index = view.GetSelectedItemIndex();
                string number = view.GetNumber();
                string subject = view.GetSubject();

                lessonDAO.UpdateItem(index, new Lesson(subject, number));

                Update();
                view.ResetTextFields();
            }
            catch
            {
                view.DisplayErrorMessage("Couldn't update this item");
                Update();
            }
        }
    }
}
