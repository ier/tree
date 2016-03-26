namespace Tree.App_Data
{
	/// <summary>
	/// Перчисление возможных типов узлов дерева
	/// </summary>
	public enum NodeType
	{
		/// <summary>
		/// Корневой узел дерева (Может содержать только каталоги)
		/// </summary>
		Root = 0,

		/// <summary>
		/// Каталог (может содержать файлы и каталоги)
		/// </summary>
		Folder = 1,

		/// <summary>
		/// Файл (не может содержать в себе других элементов)
		/// </summary>
		File = 2
	}
}