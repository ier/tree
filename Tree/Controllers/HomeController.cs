using System;
using System.Collections.Generic;
using System.Web.Mvc;

using Tree.App_Data;
using Tree.Models;

namespace Tree.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public JsonResult GetData(string id)
		{
			var nodeRepository = new NodeRepository();

			if (id == "#")
			{
				var rootNode = nodeRepository.GetRootNode();
				if (rootNode == null)
				{
					throw new ApplicationException("Не удалось найти корневой элемент дерева объектов");
				}

				var root = new JsTree3Node
				{
					id = rootNode.Id.ToString(),
					text = rootNode.Title,
					state = new State(false, false, false),
					type = "root",
					children = true
				};

				return Json(root, JsonRequestBehavior.AllowGet);
			}
			else
			{
				int parentId;
				int.TryParse(id, out parentId);
				var childNodes = nodeRepository.GetChildNodes(parentId);

				var children = new List<JsTree3Node>();
				foreach (var item in childNodes)
				{
					var node = new JsTree3Node();
					node.id = item.Id.ToString();
					node.text = item.Title;
					node.state = new State(false, false, false);

					switch ((NodeType)item.NodeType)
					{
						case NodeType.Folder:
							node.type = "folder";
							node.children = true;
							break;
						case NodeType.File:
							node.type = "file";
							node.children = false;
							break;
					}

					children.Add(node);
				}

				return Json(children, JsonRequestBehavior.AllowGet);
			}			
		}

		public ActionResult MoveNode(string id, string parentId)
		{
			var nodeRepository = new NodeRepository();

			int nodeId;
			int parentNodeId;

			int.TryParse(id, out nodeId);
			int.TryParse(parentId, out parentNodeId);

			if (nodeId > 0 && parentNodeId > 0)
			{
				nodeRepository.MoveNode(nodeId, parentNodeId);
			}		

			return null;
		}
	}
}