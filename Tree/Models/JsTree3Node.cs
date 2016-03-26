namespace Tree.Models
{
	/// <summary>
	/// Узел дерева JsTree 3-й версии
	/// </summary>
	public class JsTree3Node
	{
		/// <summary>
		/// Идентификатор узла дерева
		/// </summary>
		public string id;

		/// <summary>
		/// Отображаемый текст узла дерева
		/// </summary>
		public string text;

		/// <summary>
		/// Название иконки узла дерева
		/// </summary>
		public string icon;

		/// <summary>
		/// Состояние узла дерева
		/// </summary>
		public State state;
		public bool children;
		public string type;
	}

	/// <summary>
	/// Состояние узла JSTree 3-й версии
	/// </summary>
	public class State
	{
		/// <summary>
		/// Развернут ли узел
		/// </summary>
		public bool opened = false;

		/// <summary>
		/// Заблокирован ли узел
		/// </summary>
		public bool disabled = false;

		/// <summary>
		/// Выбран ли узел
		/// </summary>
		public bool selected = false;

		public State(bool opened, bool disabled, bool selected)
		{
			this.opened = opened;
			this.disabled = disabled;
			this.selected = selected;
		}
	}
}