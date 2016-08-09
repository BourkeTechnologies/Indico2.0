using Indico20.BusinessObjects.Base;

namespace Indico20.BusinessObjects.Objects
{
    public class MenuItem : IEntity
    {
        private UnitOfWork _unitOfWork;
        public MenuItem() { }


        public MenuItem(UnitOfWork unit)
        {
            _unitOfWork = unit;
        }

        public int ID { get; set; }
        public int ControllerAction { get; set; }
        public int? Parent { get; set; }
        public int Position { get; set; }
        public bool IsAlignedLeft { get; set; }
        public bool IsSubNav { get; set; }
        public bool IsTopNav { get; set; }
        public bool IsVisible { get; set; }
        public string Key { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        public void Add(UnitOfWork unit = null)
        {
            if (_unitOfWork == null && unit != null)
                _unitOfWork = unit;
            if (_unitOfWork != null)
                _unitOfWork.MenuItems.Add(this);

        }

        public void Delete(UnitOfWork unit = null)
        {
            if (_unitOfWork == null && unit != null)
                _unitOfWork = unit;
            if (_unitOfWork != null)
                _unitOfWork.MenuItems.Remove(ID);
        }

        public void Update(UnitOfWork unit = null)
        {
            if (_unitOfWork == null && unit != null)
                _unitOfWork = unit;
            if (_unitOfWork != null)
                _unitOfWork.MenuItems.Update(this);
        }
    }
}
