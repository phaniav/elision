﻿using System;
using Sitecore.Data;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Resources.Media;
using Sitecore.Xml.Xsl;

namespace Elision
{
    public static class ItemLinkExtensions
    {
        public static string Url(this Item item, UrlOptions options = null)
        {
            if (item == null)
                return null;

            return options != null ? LinkManager.GetItemUrl(item, options) : LinkManager.GetItemUrl(item);
        }

        public static string ImageUrl(this Item item, string imageFieldName, int? width = null, int? height = null)
        {
            var imageField = (ImageField)item?.Fields?[imageFieldName];
            return imageField?.MediaItem == null ? string.Empty : imageField.ImageUrl(width, height);
        }

        public static string ImageUrl(this Item item, ID imageFieldId, int? width = null, int? height = null)
        {
            var imageField = (ImageField)item?.Fields?[imageFieldId];
            return imageField?.MediaItem == null ? string.Empty : imageField.ImageUrl(width, height);
        }

        public static string ImageUrl(this Item item, string imageFieldName, MediaUrlOptions options)
        {
            var imageField = (ImageField)item?.Fields?[imageFieldName];
            return imageField?.MediaItem == null ? string.Empty : imageField.ImageUrl(options);
        }

        public static string ImageUrl(this Item item, ID imageFieldId, MediaUrlOptions options)
        {
            var imageField = (ImageField)item?.Fields?[imageFieldId];
            return imageField?.MediaItem == null ? string.Empty : imageField.ImageUrl(options);
        }

        public static string MediaUrl(this Item item, ID mediaFieldId, MediaUrlOptions options = null)
        {
            var targetItem = item?.TargetItem(mediaFieldId);
            if (targetItem == null)
                return string.Empty;

            return (options == null
                ? MediaManager.GetMediaUrl(targetItem)
                : MediaManager.GetMediaUrl(targetItem, options))
                   ?? string.Empty;
        }

        public static string MediaUrl(this Item item, string mediaFieldName, MediaUrlOptions options = null)
        {
            var targetItem = item?.TargetItem(mediaFieldName);
            if (targetItem == null)
                return string.Empty;

            return (options == null
                ? MediaManager.GetMediaUrl(targetItem)
                : MediaManager.GetMediaUrl(targetItem, options))
                   ?? string.Empty;
        }

        public static Item TargetItem(this Item item, ID linkFieldId)
        {
            var linkField = (LinkField)item?.Fields?[linkFieldId];
            return linkField?.TargetItem;
        }

        public static Item TargetItem(this Item item, string linkFieldName)
        {
            var linkField = (LinkField)item?.Fields?[linkFieldName];
            return linkField?.TargetItem;
        }

        public static string LinkFieldUrl(this Item item, ID fieldId)
        {
            var field = item?.Fields?[fieldId];
            if (field == null)
                return string.Empty;

            var linkUrl = new LinkUrl();
            return linkUrl.GetUrl(item, fieldId.ToString());
        }

        public static string LinkFieldUrl(this Item item, string fieldName)
        {
            var field = item?.Fields?[fieldName];
            if (field == null)
                return string.Empty;

            var linkUrl = new LinkUrl();
            return linkUrl.GetUrl(item, fieldName.ToString());
        }

        public static string LinkFieldTarget(this Item item, ID fieldId)
        {
            XmlField field = item?.Fields?[fieldId];
            return field?.GetAttribute("target");
        }

        public static string LinkFieldTarget(this Item item, string fieldId)
        {
            XmlField field = item?.Fields?[fieldId];
            return field?.GetAttribute("target");
        }

        public static string LinkFieldClass(this Item item, ID fieldId)
        {
            XmlField field = item?.Fields?[fieldId];
            return field?.GetAttribute("class");
        }

        public static string LinkFieldClass(this Item item, string fieldName)
        {
            XmlField field = item?.Fields?[fieldName];
            return field?.GetAttribute("class");
        }

        public static string LinkFieldDescription(this Item item, ID fieldId)
        {
            XmlField field = item?.Fields?[fieldId];
            return field?.GetAttribute("description");
        }

        public static string LinkFieldDescription(this Item item, string fieldName)
        {
            XmlField field = item?.Fields?[fieldName];
            return field?.GetAttribute("description");
        }
    }
}
