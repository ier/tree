using System.Collections.Generic;
using System.Linq;

namespace Tree.App_Data
{
	/// <summary>
	/// Класс предоставляет операции для работы с узлами дерева
	/// </summary>
	public class NodeRepository
	{
		/// <summary>
		/// Получить корневой узел дерева
		/// </summary>
		/// <returns>Экземпляр типа <see cref="Node"/></returns>
		internal Node GetRootNode()
		{
			var result = new Node();

			using (var db = new TreeEntities())
			{
				result = db.Node.FirstOrDefault(n => n.ParentId == null);
			}

			return result;
		}

		/// <summary>
		/// Получить список дочерних элементов указанного узла дерева
		/// </summary>
		/// <param name="parentNodeId">Идентификатор родительского узла</param>
		/// <returns>Список дочерних узлов в виде <see cref="IEnumerable<Node>"/></returns>
		internal IEnumerable<Node> GetChildNodes(int parentNodeId)
		{
			var result = new List<Node>();

			using (var db = new TreeEntities())
			{
				result = db.Node.Where(n => n.ParentId == parentNodeId).ToList();
			}

			return result;
		}

		/// <summary>
		/// Пееместить определенный узел в другой узел дерева
		/// </summary>
		/// <param name="nodeId">Идентификатор перемещаемого узла дерева</param>
		/// <param name="newParentId">Идентификатор нового родительского узла дерева</param>
		internal void MoveNode(int nodeId, int newParentId)
		{
			// Info: имитируем ожидание выполнения долгой операции
			System.Threading.Thread.Sleep(1000);

			using (var db = new TreeEntities())
			{
				var modifiedNode = db.Node.FirstOrDefault(x => x.Id == nodeId);
				if (modifiedNode != null)
				{
					modifiedNode.ParentId = newParentId;
					db.SaveChanges();
				}
			}
		}
	}
}