using SocialNetwork.core.model.players.domain;
using SocialNetwork.core.model.shared;
using System.Collections.Generic;
using SocialNetwork.core.model.tags.domain;

namespace SocialNetwork.core.model.relationships.domain
{
    public class RelationshipBuilder : IDomainBuilder<Relationship>
    {
        private Relationship _relationship;

        private PlayerId _playerDest;

        private PlayerId _playerOrig;

        private ConnectionStrength _connectionStrength;

        private readonly List<TagId> _tagsList = new();

        public RelationshipBuilder WithPlayerDest(PlayerId playerDest)
        {
            _playerDest = playerDest;
            return this;
        }

        public RelationshipBuilder WithPlayerOrig(PlayerId playerOrig)
        {
            _playerOrig = playerOrig;
            return this;
        }

        public RelationshipBuilder WithTag(TagId tag)
        {
            _tagsList.Add(tag);
            return this;
        }

        public RelationshipBuilder WithConnectionStrength(ConnectionStrength connectionStrength)
        {
            _connectionStrength = connectionStrength;
            return this;
        }

        public Relationship BuildOrIgnore()
        {
            if (_relationship != null)
                return _relationship;
            else if (_connectionStrength != null && _tagsList.Count > 0)
                _relationship = new(_playerDest, _playerOrig, _connectionStrength, _tagsList);
            else if (_connectionStrength != null)
                _relationship = new(_playerDest, _playerOrig, _connectionStrength, _tagsList);
            else
            {
                throw new System.InvalidOperationException();
            }

            return _relationship;
        }

        public Relationship Build()
        {
            var rel = BuildOrIgnore();
            _tagsList.Clear();
            _relationship = null;
            return rel;
        }
    }
}